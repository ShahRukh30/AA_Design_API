using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels
{
    public class Promocode
    {
        public int PromocodeId { get; set; }

        [Required]
        public required string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public int CodeLimit { get; set; }
        public DateTime Start_Date { get; set; }
        public DateTime Expiration_Date { get; set; }
        public int UserLimit { get; set; }
        public int Total_Usage { get; set; }
        public bool IsActive { get; set; }
    }
}
