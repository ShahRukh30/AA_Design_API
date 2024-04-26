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
        Task<string> GetClientSecret(Models.SupabaseModels.Dto.Payment.PaymentIntent productdetails);

    }
}
