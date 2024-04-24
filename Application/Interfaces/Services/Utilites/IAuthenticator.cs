using Microsoft.Extensions.Configuration;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Utilites
{
    public interface IAuthenticator
    {
        Task<bool> Verification(LoginDto dto);
        Task<object> Tokenization(LoginDto actualuser);
    }
}
