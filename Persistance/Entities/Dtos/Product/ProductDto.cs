
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Entities.Dtos.Product
{
    internal class ProductDto
    {
        public string? ProductName { get; set; }

        public int? Quantity { get; set; }

        public string? ProductDescription { get; set; }

        public decimal? Price { get; set; }

        public required string Size { get; set; }
    }
}
