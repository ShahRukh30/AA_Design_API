using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto.Payment
{
    public class PaymentIntent
    {
        [Required]
       public long Amount { get; set; }
        [Required]
       public string Currency {  get; set; }
        [Required]
        public string cardNumber {  get; set; }
        [Required]
        public string expiryMonth {  get; set; }
        [Required]
        public  string expiryYear {  get; set; }
        [Required]
        public string cvv {  get; set; }
    }
}
