
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Product
{
    public class ProductDto
    {
        public string? Productname { get; set; }

        public string? Productdescription { get; set; }
        public decimal? Price { get; set; }
        public long Productcategoryid { get; set; }
        public int XLQuantity {  get; set; }
        public int LQuantity { get; set; }
        public int MQuantity { get; set; }
        public int SQuantity { get; set; }
        public int XSQuantity { get; set; }

        public required List<IFormFile> Images { get; set; }
    }
}
