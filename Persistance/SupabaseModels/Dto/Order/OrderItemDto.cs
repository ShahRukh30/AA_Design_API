using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Order
{
    public class OrderItemDto
    {
        public long? Productid { get; set; }
        public long? Quantity { get; set; }
        public long sizeid { get; set; }
    }
}
