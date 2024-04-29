using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Factories;
using BusinessLogic.Interfaces.Services.UserService;
using BusinessLogic.Interfaces.Services.Utilites;
using Microsoft.Extensions.Configuration;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.UserService
{
    public class UserService: IUserService
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<User1> _gen;
        private readonly IUserFactory _userFactory;
    
        private readonly IConfiguration _config;

        public UserService(IMapper mapper,IGenericRepository<User1> gen,IUserFactory userFactory,  IConfiguration config)
        { 
            _gen = gen;
            
            _config = config;
            _mapper = mapper;
            _userFactory = userFactory;
        }

        public Task<User1> Post(UserDto dto)
        {
            User1 user = _mapper.Map<User1>(dto);
            user=_userFactory.CreateUser(user);
            return _gen.Post(user);
        }

        public async Task<object> Post(LoginDto loginDto)
        {

            return null;
        }
    }
}
