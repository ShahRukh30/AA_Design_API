using BusinessLogic.Interfaces.Repositories;
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
            if (days == -1)
            {
                return await _orderRepository.GetOrderList();
            }
            return await _orderRepository.GetOrderByDate(days,status);
        }

        public async Task<bool> PutStatus(long orderId, string status)
        {
            
            return await _orderRepository.PutStatus(orderId, status);

        }
    }
}
