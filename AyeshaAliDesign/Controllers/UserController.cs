using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Services;
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
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserRepository userRepository, IUserService userService)
        {
            _userRepository = userRepository;
            _userService = userService;
        }
        // public UserController(GenericService<User> gen, IMapper mapper) : base(gen, mapper)
        //{
        //}

        [HttpPost]
        [Route("register")]
        public async Task<string> Register(RegisterDto model)
        {

            return await _userService.RegisterUser(model);


        }




        //[HttpPost]
        //[Route("login")]
        //public async Task<IActionResult> Login(LoginRequest model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var user = await _userService.LoginUser(model);

        //    if (user == null)
        //    {
        //        return BadRequest("Invalid username or password");
        //    }

        //    // Generate JWT token here (consider using a secure library)
        //    // ...

        //    return Ok(new { token = "your_jwt_token" }); // Replace with actual token generation logic
        //}
    }
}

