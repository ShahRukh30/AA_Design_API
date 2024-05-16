using BusinessLogic.Interfaces.Repositories;
using DataAccess.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductSizeRepository : GenericRepo<Productsize>,IProductSizeRepository
    {
        private readonly PostgresContext _postgresContext;
        public ProductSizeRepository(PostgresContext appcontext) : base(appcontext)
        {
            _postgresContext = appcontext;
        }


        public async Task<Productsize> Update(OrderItemDto dto)
        {
            Productsize prod = await _postgresContext.Productsizes.Where(p=>p.Productid==dto.Productid && p.Sizeid==dto.sizeid).FirstAsync();
            prod.Sizequantity = prod.Sizequantity - dto.Quantity;
            return await Put(prod);
        }
    }
}
