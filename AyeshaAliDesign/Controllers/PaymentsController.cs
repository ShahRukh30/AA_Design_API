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

        [HttpPost("PaymentIntent")]
        public Task<string> Post(PaymentIntent value)
        {
            var intent = _stripe.GetClientSecret(value);
            return intent;
        }


    }
}
