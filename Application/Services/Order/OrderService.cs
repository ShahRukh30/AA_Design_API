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

        public async Task<object> GetOrderByDate(int days)
        {
            return await _orderRepository.GetOrderByDate(days);
        }
    }
}
