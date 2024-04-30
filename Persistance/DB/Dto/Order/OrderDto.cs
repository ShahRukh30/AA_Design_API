using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Order
{
    public class OrderDto
    {
        public long? Addressid { get; set; }

        public string? Dispatchid { get; set; }

        public decimal Totalprice { get; set; }

        public string? OrderProgress { get; set; }

        public string Email {  get; set; }

        public List<OrderItemDto> OrderItemss { get; set; }
    }
}
