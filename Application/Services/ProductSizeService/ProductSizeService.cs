using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Services.Generic;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.ProductSizeService
{
    public class ProductSizeService: GenericService<Productsize>
    {
        private readonly IProductSizeRepository _psizerepo;

        public ProductSizeService(IGenericRepository<Productsize> gen, IProductSizeRepository psizerepo) : base(gen)
        {
            _psizerepo=psizerepo;
        }

        public async Task<List<Productsize>> BulkUpdate(List<OrderItemDto> itemlist)
        {
            List<Productsize> final=new List<Productsize>();
            foreach (var itemDto in itemlist)
            {
              Productsize dto= await _psizerepo.Update(itemDto);
               final.Add(dto);
            }
            return final;
        }


    }
}
