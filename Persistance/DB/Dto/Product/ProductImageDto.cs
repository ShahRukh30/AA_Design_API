using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Product
{
    public class ProductImageDto
    {
        public long? Productid { get; set; }

        public string? Imageurl { get; set; }

        public string? Imagename { get; set; }

        public bool? Ismainimage { get; set; }
    }
}
