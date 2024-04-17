using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Product;

namespace BusinessLogic.Interfaces.Services.Product
{
    public interface IProductService
    {
        Task<Models.SupabaseModels.Product> Post(ProductDto Entity);
        Task<object> GetDetailsbyID(int id);
        Task<IEnumerable<object>> GetProductListing();
    }
}
