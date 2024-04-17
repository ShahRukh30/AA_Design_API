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

        Task<object> GetDetailsById(int id);
        Task<List<object>> GetProductListing();
    }
}
