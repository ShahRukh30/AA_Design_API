using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Repositories
{
    public interface IProductRepository
    {

        Task<List<Product>> Get();
        Task<List<object>> GetProductListing();
    }
}
