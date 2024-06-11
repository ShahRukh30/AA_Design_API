using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Order
{
    public interface IOrderService
    {
        Task<object> GetOrderList();
        Task<object> GetOrderByDate(int days, string status);
        Task<bool> PutStatus(long orderId, string status);
        
    }
}
