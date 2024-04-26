using BusinessLogic.Interfaces.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.SupabaseModels.Dto.Payment;
using Stripe;
using Stripe.Checkout;
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
       
        public string CreateCheckoutSession(decimal amount, string currency, string productName, string successUrl, string cancelUrl)
        {
            try
            {
                // Replace with your actual Stripe secret key
                StripeConfiguration.ApiKey = "sk_test_51OrJFLBCehTATMfqQyHN1bZQVkGVzxJyNi52rNX8Ipmhbb9T1WOhiU33LzdP5c0wmswM8qMMNUpUdHWE7xE9Xsv700NxoIWKT5";

                var options = new SessionCreateOptions
                {
                    // Allowed payment methods
                    PaymentMethodTypes = new List<string> { "card" },

                    // List of line items for the checkout session
                    LineItems = new List<SessionLineItemOptions>()
      {
        new SessionLineItemOptions
        {
          // Price data for the line item
          PriceData = new SessionLineItemPriceDataOptions
          {
            // Amount in cents (multiply by 100)
            UnitAmount = (long)(amount * 100),
            Currency = currency,

            // Product data for the line item
            ProductData = new SessionLineItemPriceDataProductDataOptions
            {
              Name = productName,
            },
          },
          // Quantity of the product (defaults to 1)
          Quantity = 1,
        },
      },

                    // Checkout session mode (payment in this case)
                    Mode = "payment",

                    // Redirect URLs after checkout success/cancellation
                    SuccessUrl = successUrl,
                    CancelUrl = cancelUrl,
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

    }
}