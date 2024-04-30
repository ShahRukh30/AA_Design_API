using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User1>
    {
         Task<User1> GetCred(LoginDto cred);
         Task<long> GetUserID(string mail);


    }
}
