using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Order;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Order
{
    public class OrderItemService:IOrderItemService
    {
        private readonly IGenericRepository<Orderitem> _gen;
        private readonly IMapper _mapper;

        public OrderItemService(IGenericRepository<Orderitem> gen)
        {
            _gen=gen;
        }

        public async Task<List<Orderitem>> Post(List<OrderItemDto> list ,long orderid)
        {
            List<Orderitem> orderitems = _mapper.Map<List<Orderitem>>(list);

            foreach (var item in orderitems)
            {
                item.Orderid = orderid;
                await _gen.Post(item);
            }

            return orderitems;
        }
    }
}
