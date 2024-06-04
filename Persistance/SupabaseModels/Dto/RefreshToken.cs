using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.SupabaseModels.Dto
{
    public class RefreshToken
    {
        public string Token {get;set;}
        public string ExpiresIn {get;set;}

    }
}
