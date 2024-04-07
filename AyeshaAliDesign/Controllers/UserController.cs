using AutoMapper;
using BusinessLogic.Services.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Models.Entities;
using Models.Entities.Dtos.User;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : SuperController<User, UserDto>
    {
        public UserController(GenericService<User> gen, IMapper mapper) : base(gen, mapper)
        {
        }

        [HttpPost("Login")]
        public string Login(string email,string p)
        {
            return "a";
        }
    }
}
