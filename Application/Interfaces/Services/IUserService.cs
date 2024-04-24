using Models.SupabaseModels.Dto.User;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services
{
    public interface IUserService
    {
        Task<User1> Post(UserDto dto);
        Task<object> Post(LoginDto loginDto);
    }
}
