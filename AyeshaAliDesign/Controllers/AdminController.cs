using BusinessLogic.Interfaces.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels.Dto;
using Models.SupabaseModels.Dto.Admin;
using Newtonsoft.Json;


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AdminController(IAuthService authService)
        {
            _authService = authService;
        }



        [HttpPost("Login")]

        public async Task<object> Login(AdminLoginDto dto)
        {
           
            RefreshToken val = new RefreshToken();
            val.Token = await _authService.Login(dto);
            val.ExpiresIn = "3600";
            return val;
        }

        [HttpPost("Logout")]

        public async Task Logout()
        {
            await _authService.Logout();
        }



        
    }
}

