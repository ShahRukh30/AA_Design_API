using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.SupabaseModels.Dto.Payment;
using Newtonsoft.Json;
using Stripe;
using Stripe.Checkout;
using Stripe.Apps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using BusinessLogic.Interfaces.Services.StripService;

namespace BusinessLogic.Services.PaymentService.StripeService
{
    public class StripeService : IStripeService
    {
        private readonly IConfiguration _config;
        private readonly string _webhookSecret;





        public StripeService(IConfiguration config)
        {
            _config = config;
            _webhookSecret = "YOUR_STRIPE_WEBHOOK_SECRET";

        }

        public string CreateCheckoutSession(decimal amount, string email, long orderid)
        {

            StripeConfiguration.ApiKey = "sk_test_51OrJFLBCehTATMfqQyHN1bZQVkGVzxJyNi52rNX8Ipmhbb9T1WOhiU33LzdP5c0wmswM8qMMNUpUdHWE7xE9Xsv700NxoIWKT5";

            var options = new SessionCreateOptions
            {

                PaymentMethodTypes = new List<string> { "card" },

                LineItems = new List<SessionLineItemOptions>()
                    {
                        new SessionLineItemOptions
                        {

                            PriceData = new SessionLineItemPriceDataOptions
                            {

                                UnitAmount = (long)(amount * 100),
                                Currency = "usd",


                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = "Your Total",
                                },
                            },

                            Quantity = 1,
                        },

                    },
                Mode = "payment",
                //BillingAddressCollection = "required",
                SuccessUrl = "https://ayeshaalidesign.vercel.app/payment-success",
                CancelUrl = "https://ayeshaalidesign.vercel.app/payment-fail",

                Metadata = new Dictionary<string, string>
                {
                    { "orderid", orderid.ToString() } // Add orderid to metadata
                },
                CustomerEmail = email // Populate email field with passed parameter




            };

            var service = new SessionService();
            var session = service.Create(options);

            return session.Url;
        }

        string IStripeService.CreateCheckoutSession(decimal amount, string email, long orderid)
        {
            throw new NotImplementedException();
        }







        public async Task PaymnentWebHook(HttpRequest request)
        {

            var endpointSecret = "whsec_GKrTYjUysxcMhmnSqAgmXCnIDp9TfVri\r\n";
            var json = await new StreamReader(request.Body).ReadToEndAsync();

            var stripeEvent = EventUtility.ConstructEvent(json,
                request.Headers["Stripe-Signature"], endpointSecret);

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {
                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {

                }

            }


        }



    }
}
