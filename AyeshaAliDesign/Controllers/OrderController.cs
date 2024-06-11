using BusinessLogic.Interfaces.Services.Order;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderservice;
        public OrderController(IOrderService orderService)
        {
            _orderservice = orderService;
        }

        [HttpGet("list")]
        public async Task<object> GetOrderList()
        {
            return await _orderservice.GetOrderList();  
        }

        [HttpGet("date/{days}")]
        public async Task<object> GetOrderByDate(int days,string status)
        {
            return await _orderservice.GetOrderByDate(days, status);
        }

        [HttpPut("status")]
        public async Task<object> PutStatus(long orderid, string status)
        {
            return await _orderservice.PutStatus(orderid, status);
        }


    }
}
