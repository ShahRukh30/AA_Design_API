﻿using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Order
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<object> GetOrderList()
        {
            return await _orderRepository.GetOrderList();
        }

        public async Task<object> GetOrderByDate(int days,string status)
        {
            return await _orderRepository.GetOrderByDate(days,status);
        }

        private async Task<bool> PatchDeliveryDate(long orderid)
        {
            return await _orderRepository.PatchDeliveryDate(orderid);
        }

        public async Task<bool> PutStatus(long orderId, string status)
        {
            if (status == "Delivered")
            {
                bool val= await _orderRepository.PutStatus(orderId, status);
                await PatchDeliveryDate(orderId);
                return val;
            }
            
            return await _orderRepository.PutStatus(orderId, status);
        }

        public async Task<decimal?> PatchPrice (long orderid, long? price)
        {
            decimal amount = (decimal)price / 100;
            return await _orderRepository.PatchPrice(orderid, amount);

        }

        public async Task<object> GetOrderDetails(long orderid)
        {
            return await _orderRepository.GetOrderDetails(orderid);
        }
    }
}
