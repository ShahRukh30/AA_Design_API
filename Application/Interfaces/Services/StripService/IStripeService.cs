using Microsoft.AspNetCore.Http;
using Models.SupabaseModels.Dto.Payment;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.StripService
{
    public interface IStripeService
    {
        string CreateCheckoutSession(decimal amount);
        Task ProcessWebhookEvent(HttpRequest request);
    }
}
