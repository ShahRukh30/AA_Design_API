using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Payment
{
    public class PaymentDto
    {
        public long? Userid { get; set; }

        public long? Orderid { get; set; }

        public string? Paymentstatus { get; set; }

        public DateTime? Paymenttimestamp { get; set; }

    }
}
