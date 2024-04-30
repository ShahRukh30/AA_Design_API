using Models.SupabaseModels.Dto.Order;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Order
{
    public interface IOrderItemService
    {
        Task<List<OrderItemDto>> Post(List<OrderItemDto> list, long orderid);
    }
}
