using Microsoft.AspNetCore.Http;
using Models.SupabaseModels.Dto.Order;
using Models.SupabaseModels.Dto.Payment;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.StripService
{
    public interface IStripeService
    {
       string CreateCheckoutSession(decimal amount, string email, long orderid, long addressid, List<OrderItemDto> sizearray);
       public Task PaymnentWebHook(string json, string head, string endpoint);

    }
}
