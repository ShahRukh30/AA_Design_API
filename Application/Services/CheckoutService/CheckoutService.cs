using BusinessLogic.Interfaces.Services.AddressService;
using BusinessLogic.Interfaces.Services.UserService;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CheckoutService
{
    public class CheckoutService
    {

        private readonly IUserService _user;
        private readonly IAddressService _address;
        public CheckoutService(IUserService user, IAddressService address) {
            _user= user;
            _address= address;
        }

        public async Task<long> Post(UserDto user)
        {
            User1 userdetail = await _user.Post(user);
            Deliveryadress addressfinal = await _address.Post(user, userdetail.Userid);
            return addressfinal.Adressid;
        }

        public async Task<string> Post(long productid,decimal ammount, long deliveryid,List<int> a)
        {
            return null;
        }
    }
}
