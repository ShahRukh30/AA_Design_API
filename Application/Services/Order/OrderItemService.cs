using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Order;
using BusinessLogic.Interfaces.Services.Utilites;
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
        private readonly ISizeConverter _prodsize;

        public OrderItemService(ISizeConverter prodsize,IGenericRepository<Orderitem> gen, IMapper mapper)
        {
            _gen=gen;
            _mapper=mapper;
            _prodsize=prodsize;
        }

        public async Task<List<OrderItemDto>> Post(List<OrderItemDto> list ,long orderid)
        {
          

            foreach (var item in list)
            {
                Orderitem a=_mapper.Map<Orderitem>(item);
                a.Orderid = orderid;
                a.ProductSizes = _prodsize.GetSizeString(item.sizeid);
                await _gen.Post(a);
            }

            return list;
        }
    }
}
