using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels.Dto.Payment;
using Models.SupabaseModels.Dto.User;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly IStripeService _stripe;

        public PaymentsController(IStripeService stripe)
        {
            _stripe=stripe;
        }

        

        [HttpGet("CheckoutSession")]
        public string getsession(decimal amount, string currency, string productName, string successUrl, string cancelUrl)
        {
            successUrl = "https://example.com/success";
            cancelUrl= "https://example.com/success";

            return _stripe.CreateCheckoutSession(amount,currency,productName,successUrl,cancelUrl);
        }

    }
}
