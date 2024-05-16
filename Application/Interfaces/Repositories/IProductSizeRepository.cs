using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Repositories
{
    public interface IProductSizeRepository : IGenericRepository<Productsize>
    {
        Task<Productsize> Update(OrderItemDto dto);
        Task<List<long?>> GetAvailableSizes(long productid);
    }
}
