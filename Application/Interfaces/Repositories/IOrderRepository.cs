using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Repositories
{
    public interface IOrderRepository: IGenericRepository<Order>
    {
        Task<object> GetOrderList();
        Task<bool> PatchDeliveryDate(long orderId);
        Task<decimal?> PatchPrice(long orderId, decimal amount);
        Task<object> GetOrderByDate(int days,string status);
        Task<bool> PutStatus(long orderId, string status);
        Task<object> GetOrderDetails(long orderid);


    }
}
