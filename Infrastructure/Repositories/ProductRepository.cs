using BusinessLogic.Interfaces.Repositories;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        IGenericRepository<Productsize> _psize;
        PostgresContext _context;
        public ProductRepository(PostgresContext context)
        {
            _context = context;
        }
        public async Task<List<Product>> Get()
        {
            return await _context.Products
                .Include(p => p.Productsizes)
                .Include(p => p.Productimages)
                .Include(p => p.Productcategory)
                .ToListAsync();
        }

        public async Task<List<object>> GetProductListing()
        {
            var query = from product in _context.Products
                        join category in _context.Productcategories on product.Productcategoryid equals category.Productcategoryid
                        join image in _context.Productimages on product.Productid equals image.Productid
                        where image.Ismainimage == true
                        select new
                        {
                            ProductId = product.Productid,
                            CategoryName = category.Productcategory1,
                            ImageUrl = image.Imageurl
                        };

            return (await query.ToListAsync())
          .Cast<object>()
          .ToList();
        }

    }
}
