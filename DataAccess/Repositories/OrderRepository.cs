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
                }
            }

           

            var result = await query.ToListAsync<object>();


            return result;
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

    }
}
