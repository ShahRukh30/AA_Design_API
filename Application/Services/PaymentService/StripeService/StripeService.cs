using BusinessLogic.Interfaces.Services;
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
       
        public string CreateCheckoutSession(decimal amount)
        {
            try
            {
                // Replace with your actual Stripe secret key
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

                   
               


                };

                var service = new SessionService();
                var session = service.Create(options);

                return session.Url;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it differently based on your needs
                throw new Exception($"Failed to create checkout session: {ex.Message}");
            }
        }





        public async Task ProcessWebhookEvent(HttpRequest request)
        {
            try
            {
                var endpointSecret = "YOUR_STRIPE_WEBHOOK_SECRET"; 
                var json = await new StreamReader(request.Body).ReadToEndAsync();

                var stripeEvent = EventUtility.ConstructEvent(json,
                    request.Headers["Stripe-Signature"], endpointSecret);

                switch (stripeEvent.Type)
                {
                    case Events.CheckoutSessionCompleted:
                        var session = stripeEvent.Data.Object as Session;
                        await HandleCheckoutSessionCompleted(session);
                        break;
                    case Events.PaymentIntentSucceeded:
                        var paymentIntent = stripeEvent.Data.Object as Stripe.PaymentIntent;
                        await HandlePaymentIntentSucceeded(paymentIntent);
                        break;
                   
                    default:
                        Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);
                        break;
                }

                return;
            }
            catch (StripeException ex)
            {
                Console.WriteLine("Error processing Stripe webhook: {0}", ex.Message);
                throw; 
            }
        }

        private async Task HandleCheckoutSessionCompleted(Session session)
        {
            
            Console.WriteLine($"Checkout Session Completed: {session.Id}");
        }

        private async Task HandlePaymentIntentSucceeded(Stripe.PaymentIntent paymentIntent)
        { 
            Console.WriteLine($"Payment Intent Succeeded: {paymentIntent.Id}");
        }

    }
    }
