using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services.PaymentService.StripeService;
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
        public string getsession(decimal amount)
        {
            return _stripe.CreateCheckoutSession(amount);
        }

        [HttpPost("Payment-Event")]
        public async Task<IActionResult> Webhook(HttpRequest request)
        {
            await _stripe.ProcessWebhookEvent(request);
            return Ok();
        }

    }
}
