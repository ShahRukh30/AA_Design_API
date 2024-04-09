using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Services.Generic;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.ProductService
{
    public class ProductCategoryService : GenericService<Productcategory>, IProductCategoryService
    {
        public ProductCategoryService(IGenericRepository<Productcategory> gen) : base(gen)
        {
        }
    }
}
