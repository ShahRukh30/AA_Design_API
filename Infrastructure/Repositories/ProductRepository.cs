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
    //return await _context.Products
    //    .Include(p => p.Productsizes)
    //    .Include(p => p.Productimages)
    //    .Include(p => p.Productcategory)
    //    .FirstOrDefaultAsync(p=>p.Productid==id);
    public class ProductRepository : IProductRepository
    {
        
        PostgresContext _context;
        public ProductRepository(PostgresContext context)
        {
            _context = context;
        }
        public async Task<object> GetDetailsById(int id)
        {
            var query= from product in _context.Products
                       join category in _context.Productcategories on product.Productcategoryid equals category.Productcategoryid
                       //join productsize in _context.Productsizes on product.Productid equals productsize.Productid
                       join image in _context.Productimages on product.Productid equals image.Productid
                       where image.Ismainimage == true
                       select new
                       {
                           ProductId = product.Productid,
                           ProductName = product.Productname,
                           ProductDescription=product.Productdescription,
                           ProductQuantity=product.Quantity,
                           CategoryID=product.Productcategoryid,
                           ProductPrice = product.Price,
                           CategoryName = category.Productcategory1,
                           ImageUrl = image.Imageurl,
                           ProductSizes = _context.Productsizes
                        .Where(ps => ps.Productid == product.Productid)
                         .Select(ps => new 
                         {
                             SizeId = ps.Sizeid,
                             SizeQuantity = ps.Sizequantity
                         })
                                    .ToList()
                       };
            return await query.FirstOrDefaultAsync();
          
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
                            ProductName=product.Productname,
                            ProductPrice=product.Price,
                            CategoryName = category.Productcategory1,
                            ImageUrl = image.Imageurl
                        };

            return (await query.ToListAsync())
          .Cast<object>()
          .ToList();
        }

    }
}
