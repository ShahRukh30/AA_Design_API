using Models.SupabaseModels.Dto.Payment;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services
{
    public interface IStripeService
    {
        string CreateCheckoutSession(decimal amount, string currency, string productName, string successUrl, string cancelUrl);
    }
}
