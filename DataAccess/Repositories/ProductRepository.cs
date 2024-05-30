using BusinessLogic.Interfaces.Repositories;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Newtonsoft.Json;
using Supabase.Interfaces;
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

        public Task<List<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public async Task<object> GetDetailsById(int id)
        {
            var url = "https://lbqpoifccgmqlsydhvke.supabase.co";
            var key = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6ImxicXBvaWZjY2dtcWxzeWRodmtlIiwicm9sZSI6ImFub24iLCJpYXQiOjE3MTI2MDE4NDYsImV4cCI6MjAyODE3Nzg0Nn0.EkMkG3X1inJUPs0Y0_GFCnVBCidQ2VMtTlINCw3Xu8A";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();

            var functionName = "get_product_details"; // Adjusted function name
            var response = await supabase.Rpc(functionName, new Dictionary<string, object> { {"input_id", id} }); // Adjusted parameter name
            var details = JsonConvert.DeserializeObject<object>(response.Content);
            return details;
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
                            ProductDetail=product.details,
                            CategoryName = category.Productcategory1,
                            ImageUrl = image.Imageurl
                        };

            return (await query.ToListAsync())
          .Cast<object>()
          .ToList();
        }

    }
}
