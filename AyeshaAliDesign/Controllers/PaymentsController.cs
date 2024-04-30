using BusinessLogic.Interfaces.Services.StripService;
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
        public string getsession(decimal amount,string email,long orderid)
        {
            return _stripe.CreateCheckoutSession(amount,email,orderid);
        }

      

    }
}
