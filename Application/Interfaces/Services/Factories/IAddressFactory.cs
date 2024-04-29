using Models.SupabaseModels.Dto.User;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Factories
{
    public interface IAddressFactory
    {
        public Deliveryadress CreateAddress(UserDto dto, long userid);
    }
}
