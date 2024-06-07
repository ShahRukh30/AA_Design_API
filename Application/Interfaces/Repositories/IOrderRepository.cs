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
        Task<object> GetOrderByDate(int days);
    }
}
