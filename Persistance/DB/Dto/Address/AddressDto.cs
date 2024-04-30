using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Address
{
    public class AddressDto
    {
        public required int UserId { get; set; }
        public required string PostalCode { get; set; }

        public required string Country { get; set; }

        public required string State { get; set; }
        public required string City { get; set; }

        public required string Street { get; set; }

        public required string Address { get; set; }
    }
}
