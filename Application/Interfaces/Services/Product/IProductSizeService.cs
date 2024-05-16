using BusinessLogic.Interfaces.Services.GenericService;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Product
{
    public interface IProductSizeService:IGenericService<Productsize>
    {
        Task<List<Productsize>> BulkUpdate(List<OrderItemDto> itemlist);
    }
}
