using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Product
{
    public class ProductSizeDto
    {
        public long? Productid { get; set; }

        public long? Sizeid { get; set; }

        public long? Sizequantity { get; set; }
    }
}
