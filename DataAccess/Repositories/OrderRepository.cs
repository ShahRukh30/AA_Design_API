using BusinessLogic.Interfaces.Repositories;
using DataAccess.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using Stripe.Climate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepo<Models.SupabaseModels.Order>, IOrderRepository
    {
        private readonly PostgresContext _appcontext;
        public OrderRepository(PostgresContext appcontext) : base(appcontext)
        {
            _appcontext = appcontext;
        }

        public async Task<decimal?> PatchPrice(long orderId, decimal amount)
        {
            var order = await _appcontext.Orders.FindAsync(orderId);
            order.Totalprice = amount;

            // Save the changes to the database
            await _appcontext.SaveChangesAsync();

            return order.Totalprice;

        }

        public async Task<bool> PatchDeliveryDate(long orderId)
        {
            var order = await _appcontext.Orders.FindAsync(orderId);
            if (order == null)
            {
                return false;
            }
            order.DeliveryDate = DateTime.UtcNow;

            // Save the changes to the database
            await _appcontext.SaveChangesAsync();

            return true;

        }
        public async Task<bool> PutStatus(long orderId, string status)
        {
            var order = await _appcontext.Orders.FindAsync(orderId);
            if (order == null) {
                return false;
            }
            order.OrderProgress = status;

            // Save the changes to the database
            await _appcontext.SaveChangesAsync();

            return true;

        }
        public async Task<object> GetOrderByDate(int days,string status)
        {
            
            DateTime filter = DateTime.UtcNow.Date.AddDays(-days);

            var query = from order in _appcontext.Orders
                        join address in _appcontext.Deliveryadresses
                        on order.Addressid equals address.Adressid
                        join user1 in _appcontext.Users1
                        on address.Userid equals user1.Userid
                        select new
                        {
                            OrderId = order.Orderid,
                            CustomerName = user1.Firstname + " " + user1.Lastname,
                            ClientEmail = user1.Email,
                            PhoneNumber = user1.Phone,
                            TrackingId = order.Dispatchid,
                            DeliveryAddress = address.Deliveryaddress,
                            ZipCode = address.Zipcode,
                            OrderAmount = order.Totalprice,
                            DeliveryStatus = order.OrderProgress,
                            OrderDate = order.OrderDate 
                        };

            if (days> -1)
            {
                query = query.Where(order => order.OrderDate >= filter);

                if (!string.Equals(status, "All", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(order => order.DeliveryStatus == status);
                    return await query.ToListAsync<object>();
                }
                else
                {
                    return await query.ToListAsync<object>();
                }
            }
            else
            {
                if (!string.Equals(status, "All", StringComparison.OrdinalIgnoreCase))
                {
                    query = query.Where(order => order.DeliveryStatus == status);
                    return await query.ToListAsync<object>();
                }
                else
                {
                    return await query.ToListAsync<object>();
                }
            }
           

            //var result = await query.ToListAsync<object>();


            //return result;
        }


        public async Task<object> GetOrderList()
        {
            var result = await (from order in _appcontext.Orders
                                join address in _appcontext.Deliveryadresses
                                on order.Addressid equals address.Adressid
                                join user1 in _appcontext.Users1
                                on address.Userid equals user1.Userid
                                select new
                                {
                                    OrderId = order.Orderid,
                                    CustomerName = user1.Firstname + " " + user1.Lastname,
                                    ClientEmail=user1.Email,
                                    PhoneNumber=user1.Phone,
                                    DeliveryAddress = address.Deliveryaddress,
                                    ZipCode=address.Zipcode,
                                    OrderAmount=order.Totalprice,
                                    DeliveryStatus=order.OrderProgress
                                }).ToListAsync();

            return result;
        }


        public async Task<object> GetOrderDetails(long orderid)
        {
            
            var result = await (from orderitem in _appcontext.Orderitems
                                where orderitem.Orderid == orderid
                                join product in _appcontext.Products
                                on orderitem.Productid equals product.Productid
                                join order in _appcontext.Orders
                                on orderitem.Orderid equals order.Orderid
                                group new { orderitem, product } by order.Orderid into g
                                select new
                                {
                                    OrderId = orderid,
                                    TotalPrice = g.First().orderitem.Order.Totalprice,
                                    DispatchId = g.First().orderitem.Order.Dispatchid,
                                    OrderProgress = g.First().orderitem.Order.OrderProgress,
                                    Products = g.Select(x => new
                                    {
                                        ProductName = x.product.Productname,
                                        ProductSizes = x.orderitem.ProductSizes,
                                        ProductPrice=x.product.Price,
                                        Quantity = x.orderitem.Quantity,
                                    }).ToList()

                                .ToList(),
                                   
                                    TotalQuantity = g.Sum(x => x.orderitem.Quantity) // Calculate total quantity
                                }).ToListAsync();




            return result;
        }
    }
}
