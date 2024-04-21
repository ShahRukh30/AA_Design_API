using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using Models.SupabaseModels.Extras;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
           
        }

        public async Task<string> RegisterUser(RegisterDto user)
        {
           
            User1 userfinal= _mapper.Map<User1>(user);
            userfinal.Isactive = false;
            userfinal.Roleid = 2;
            

            _userRepository.RegisterDto(userfinal);

            return "Successfully registered";
        }
    }
}
