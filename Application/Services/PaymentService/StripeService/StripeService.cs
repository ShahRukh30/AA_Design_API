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
using BusinessLogic.Interfaces.Services.Factories;
using BusinessLogic.Interfaces.Services.UserService;
using BusinessLogic.Interfaces.Repositories;
using Stripe.Forwarding;

namespace BusinessLogic.Services.PaymentService.StripeService
{
    public class StripeService : IStripeService
    {
        private readonly IConfiguration _config;
        private readonly string _webhookSecret;
        private readonly IPaymentFactory _paymentfactory;
        private readonly IUserService _user;
        private readonly IGenericRepository<Models.SupabaseModels.Payment> _payment;


        public StripeService(IConfiguration config, IPaymentFactory paymentfactory,IUserService user, IGenericRepository<Models.SupabaseModels.Payment> payment)
        {
            _config = config;
            _paymentfactory = paymentfactory;
            _user = user;
            _payment = payment;

        }

      
            public string CreateCheckoutSession(decimal amount, string email, long orderid,long addressid)
        {

            StripeConfiguration.ApiKey = "sk_test_51P7jFlLesCixaoVsSFLbQZE2Z9khCKHOSsFYtd0S20bvYg962eHNk8sRRwKKisfXnl1iwTjq0sSrw1YfrAlG0Rd400ZEe0PzQy";

            var options = new SessionCreateOptions
            {

                PaymentMethodTypes = new List<string> { "card" },
                ShippingAddressCollection = new Stripe.Checkout.SessionShippingAddressCollectionOptions
                {
                    AllowedCountries = new List<string> { "US" },

                },
                ShippingOptions = new List<Stripe.Checkout.SessionShippingOptionOptions>
                
                { new Stripe.Checkout.SessionShippingOptionOptions
                 {
                  ShippingRateData = new Stripe.Checkout.SessionShippingOptionShippingRateDataOptions
                     {
                    Type = "fixed_amount",
                   FixedAmount = new Stripe.Checkout.SessionShippingOptionShippingRateDataFixedAmountOptions
                {
                    Amount = 1500,
                    Currency = "usd",
                },
                DisplayName = "Shipping",
                DeliveryEstimate = new Stripe.Checkout.SessionShippingOptionShippingRateDataDeliveryEstimateOptions
                {
                    Minimum = new Stripe.Checkout.SessionShippingOptionShippingRateDataDeliveryEstimateMinimumOptions
                    {
                        Unit = "business_day",
                        Value = 5,
                    },
                    Maximum = new Stripe.Checkout.SessionShippingOptionShippingRateDataDeliveryEstimateMaximumOptions
                    {
                        Unit = "business_day",
                        Value = 7,
                        },
                            },
                             },
                         },
                            },

                    AutomaticTax = new Stripe.Checkout.SessionAutomaticTaxOptions { Enabled = true },

                LineItems = new List<SessionLineItemOptions>()
                    {
                        new SessionLineItemOptions
                        {

                            PriceData = new SessionLineItemPriceDataOptions
                            {

                                UnitAmount = (long)(amount * 100) ,
                                Currency = "usd",
                                TaxBehavior = "exclusive",

                                ProductData = new SessionLineItemPriceDataProductDataOptions
                                {
                                    Name = "Your Total",
                                },

                            },

                            Quantity = 1,

                        },

                    },
                Mode = "payment",

             
           

                SuccessUrl = "https://ayeshaalidesign.vercel.app/payment-success",
                CancelUrl = "https://ayeshaalidesign.vercel.app/payment-fail",

                Metadata = new Dictionary<string, string>
                {
                    { "orderid", orderid.ToString() } ,

                },
                CustomerEmail = email 




            };

            var service = new SessionService();
            var session = service.Create(options);



            return session.Url;
        }


        public async Task PaymnentWebHook(string json,string head,string endpoint)
        {

            var stripeEvent = EventUtility.ConstructEvent(json, head, endpoint,300,false);

            if (stripeEvent.Type == Events.CheckoutSessionCompleted)
            {

               
                var session = (Stripe.Checkout.Session)stripeEvent.Data.Object;
                var metadata = session.Metadata;
                long orderId = metadata.TryGetValue("orderid", out string orderIdValue) && long.TryParse(orderIdValue, out long tempOrderId) ? tempOrderId : -1L;
                string email = session.CustomerEmail;
                long userid = await _user.Get(email);
                
                Models.SupabaseModels.Payment finalresult = _paymentfactory.CreatePayment(orderId, userid);
                await _payment.Post(finalresult);

                if (stripeEvent.Type == Events.PaymentIntentSucceeded)
                {
                    var paymentIntent = (Stripe.PaymentIntent)stripeEvent.Data.Object;
                    var shippingAddress = paymentIntent.Shipping.Address;
                    string city = shippingAddress.City;
                    string country = shippingAddress.Country;
                    string line1 = shippingAddress.Line1;
                    string line2 = shippingAddress.Line2;
                    string postalCode = shippingAddress.PostalCode;
                    string state = shippingAddress.State;
                }
                

            }


        }



    }
}
