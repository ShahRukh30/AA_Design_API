using BusinessLogic.Interfaces.Services.Factories;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Utilities.Factories.Address
{
    public class AddressFactory:IAddressFactory
    {

        public Deliveryadress CreateAddress(UserDto dto ,long userid)
        {
            Deliveryadress user = new Deliveryadress
            {
                Userid = userid,
                Deliveryaddress = dto.State+" "+dto.City+" "+dto.Street+" "+dto.Address,
                Zipcode=dto.PostalCode,
                Cityid=1947,
                Stateid=52,

            };

          

            return user;
        }

        
    }
}
