using Models.SupabaseModels.Dto.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.AuthService
{
    public interface IAuthService
    {
        Task<string> Login(AdminLoginDto dto);
        Task Logout();

        Task<string> RefreshToken();
    }
}
