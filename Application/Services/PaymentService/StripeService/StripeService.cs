using BusinessLogic.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.SupabaseModels.Dto.Payment;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.PaymentService.StripeService
{
    public class StripeService : IStripeService
    {
       private readonly IConfiguration _config;

        public StripeService(IConfiguration config)
        {
            _config = config;
        }
        public async Task<string> GetClientSecret(Models.SupabaseModels.Dto.Payment.PaymentIntent productdetails)
        {
            var config = _config.GetSection("Stripe");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["SecretKey"]!));
            StripeConfiguration.ApiKey = "sk_test_51OrJFLBCehTATMfqQyHN1bZQVkGVzxJyNi52rNX8Ipmhbb9T1WOhiU33LzdP5c0wmswM8qMMNUpUdHWE7xE9Xsv700NxoIWKT5";
            decimal val = (decimal)productdetails.Amount * 100;
            var options = new PaymentIntentCreateOptions
            {
                Amount = (long?)val,
                Currency = productdetails.Currency,
                AutomaticPaymentMethods = new PaymentIntentAutomaticPaymentMethodsOptions
                {
                    Enabled = true,
                },
            };

            var service = new PaymentIntentService();
            var intent = await service.CreateAsync(options); 

            return intent.ClientSecret;

        }
    }
}
