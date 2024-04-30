using Models.SupabaseModels.Dto.Order;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.CheckoutService
{
   public interface ICheckoutService
    {
        Task<long> Post(UserDto user);
        Task<string> Post(OrderDto dto, long orderid);
    }
}
