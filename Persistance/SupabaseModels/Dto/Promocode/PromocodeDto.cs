using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Promocode
{
    public class PromocodeDto
    {
        [Required]
        public required string Code { get; set; }
        public decimal DiscountAmount { get; set; }
        public int CodeLimit { get; set; }
        public DateOnly Start_Date { get; set; }
        public DateOnly Expiration_Date { get; set; }
        public int UserLimit { get; set; }
        public int Total_Usage { get; set; }
        public bool IsActive { get; set; }
    }
}
