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

        public OrderItemService(IGenericRepository<Orderitem> gen, IMapper mapper)
        {
            _gen=gen;
            _mapper=mapper;
        }

        public async Task<List<OrderItemDto>> Post(List<OrderItemDto> list ,long orderid)
        {
          

            foreach (var item in list)
            {
                Orderitem a=_mapper.Map<Orderitem>(item);
                a.Orderid = orderid;
                await _gen.Post(a);
            }

            return list;
        }
    }
}
