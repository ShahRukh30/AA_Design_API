using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.AddressService;
using BusinessLogic.Interfaces.Services.CheckoutService;
using BusinessLogic.Interfaces.Services.Order;
using BusinessLogic.Interfaces.Services.StripService;
using BusinessLogic.Interfaces.Services.UserService;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Order;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.CheckoutService
{
    public class CheckoutService:ICheckoutService
    {

        private readonly IUserService _user;
        private readonly IAddressService _address;
        private readonly IGenericRepository<Models.SupabaseModels.Order> _gen;
        private readonly IMapper _mapper;
        private readonly IOrderItemService _orderitem;
        private readonly IStripeService _stripe;
        public CheckoutService(IUserService user, IAddressService address, IGenericRepository<Models.SupabaseModels.Order> gen,
            IOrderItemService orderItem,IStripeService stripe) {
            _user= user;
            _address= address;
            _gen= gen;
            _orderitem=orderItem;
            _stripe =stripe;
        }

        public async Task<long> Post(UserDto user)
        {
            User1 userdetail = await _user.Post(user);
            Deliveryadress addressfinal = await _address.Post(user, userdetail.Userid);
            return addressfinal.Adressid;
        }

        public async Task<string> Post(OrderDto dto,long orderid)
        {
            Models.SupabaseModels.Order order = _mapper.Map<Models.SupabaseModels.Order>(dto);
            order = await _gen.Post(order);
            order.Dispatchid = Guid.NewGuid().ToString();
            order.OrderProgress = "Pending";
            await _orderitem.Post(dto.OrderItemss, order.Orderid);
            return _stripe.CreateCheckoutSession(dto.Totalprice,dto.Email,order.Orderid);

        }
    }
}
