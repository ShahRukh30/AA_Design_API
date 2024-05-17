using BusinessLogic.Interfaces.Services.CheckoutService;
using BusinessLogic.Interfaces.Services.StripService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels.Dto.Order;
using Models.SupabaseModels.Dto.User;
using Newtonsoft.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class CheckoutController : ControllerBase
    {
        private readonly ICheckoutService _checkout;

        public CheckoutController(IStripeService stripe, ICheckoutService checkout)
        {

            _checkout = checkout;
        }


      
        [HttpPost("checkout-session")]
        public async Task<string> Getsession(OrderDto dto)
        {
            return JsonConvert.SerializeObject(await _checkout.Post(dto));
        }

        [HttpPost("checkout-prepare")]
        public async Task<long> CheckoutDetails(UserDto dto)
        {
            return await _checkout.Post(dto);
        }
    }
}

