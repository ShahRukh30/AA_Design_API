using AutoMapper;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _config;
        public UserController(IUserService gen, IUserService uservice, IMapper mapper) 
        {
            _userService = uservice;
        }

        [HttpPost("Login")]
        public Task<object> Login(LoginDto dto)
        {
            return _userService.Post(dto);
        }


        [HttpPost("Register")]
        public Task<User1> Register([FromBody] UserDto dto)
        {
            return _userService.Post(dto);
        }
    }
}
