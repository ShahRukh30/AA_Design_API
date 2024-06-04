using BusinessLogic.Interfaces.Services.AuthService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels.Dto.Admin;

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

        public async Task<string> Login(AdminLoginDto dto)
        {
            return await _authService.Login(dto);
        }

        [HttpPost("Logout")]

        public async Task Logout()
        {
            await _authService.Logout();
        }



        [HttpGet("refresh-token")]

        public async Task<string> refreshtoken()
        {
           return await _authService.RefreshToken();
        }

    }
}

