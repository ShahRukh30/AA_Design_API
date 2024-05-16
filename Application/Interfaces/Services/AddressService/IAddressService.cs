using BusinessLogic.Interfaces.Services.GenericService;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.AddressService
{
    public  interface IAddressService:IGenericService<Deliveryadress>
    {

       
        Task<Deliveryadress> Post(UserDto dto, long userid);
    }
}
