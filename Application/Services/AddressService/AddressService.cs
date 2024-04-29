using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.AddressService;
using BusinessLogic.Interfaces.Services.Factories;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.AddressService
{
    public class AddressService : IAddressService
    { 
        private readonly IGenericRepository<Deliveryadress> _deliveryadressRepository;
        private readonly IAddressFactory _addressFactory;
        public AddressService(IGenericRepository<Deliveryadress> deliveryadressRepository,IAddressFactory addressFactory)
        {
            _deliveryadressRepository = deliveryadressRepository;
            _addressFactory = addressFactory;
            
        }
        public async Task<Deliveryadress> Post(UserDto dto,long userid)
        {
           Deliveryadress val= _addressFactory.CreateAddress(dto,userid);
            return await _deliveryadressRepository.Post(val);
        }

        
    }
}
