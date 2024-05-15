using BusinessLogic.Interfaces.Services.StripService;
using BusinessLogic.Services.PaymentService.StripeService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels.Dto.Payment;
using Models.SupabaseModels.Dto.User;
using Stripe;

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

        

        //[HttpGet("CheckoutSession")]
        //public string getsession(decimal amount,string email,long orderid)
        //{
        //    return _stripe.CreateCheckoutSession(amount,email,orderid);
        //}

        [HttpPost("")]
        public async Task<IActionResult> Check()
        {
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            var endpointSecret = "whsec_92a50f4783a166c8fa914b3eec19c89bfd06c02c39ae32fc5529a460b7c4adfc";
            try
            {
                var stripeEvent = EventUtility.ConstructEvent(json,
                    Request.Headers["Stripe-Signature"], endpointSecret);

                // Handle the event
                Console.WriteLine("Unhandled event type: {0}", stripeEvent.Type);

                return Ok();
            }
            catch (StripeException e)
            {
                return BadRequest();
            }
        }


        [HttpPost("Payment-Event")]
        public async Task<IActionResult> Webhook()
        {
            var endpointSecret = "whsec_WGHoXI62SwUr6D8pUiJ1cfGBi2DtYEn8";
            var signature = HttpContext.Request.Headers["Stripe-Signature"];
            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();
            await _stripe.PaymnentWebHook(json, signature, endpointSecret);

            return Ok("Done");
        }

    }
}
