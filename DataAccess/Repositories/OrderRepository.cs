using BusinessLogic.Interfaces.Repositories;
using DataAccess.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class OrderRepository : GenericRepo<Order>, IOrderRepository
    {
        private readonly PostgresContext _appcontext;
        public OrderRepository(PostgresContext appcontext) : base(appcontext)
        {
            _appcontext = appcontext;
        }

        public async Task<object> GetOrderByDate(int days)
        {
            // Calculate the filter date in UTC
            DateTime filter = DateTime.UtcNow.Date.AddDays(-days);

            var result = await (from order in _appcontext.Orders
                                join address in _appcontext.Deliveryadresses
                                on order.Addressid equals address.Adressid
                                join user1 in _appcontext.Users1
                                on address.Userid equals user1.Userid
                                where order.OrderDate >= filter
                                select new
                                {
                                    OrderId = order.Orderid,
                                    CustomerName = user1.Firstname + " " + user1.Lastname,
                                    ClientEmail = user1.Email,
                                    PhoneNumber = user1.Phone,
                                    DeliveryAddress = address.Deliveryaddress,
                                    ZipCode = address.Zipcode,
                                    OrderAmount = order.Totalprice,
                                    DeliveryStatus = order.OrderProgress
                                }).ToListAsync<object>();

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
