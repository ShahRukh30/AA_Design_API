using API.DB;
using BusinessLogic.Interfaces.Repositories;
using DataAccess.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepo<Models.SupabaseModels.User1>, IUserRepository
    {
        private readonly PostgresContext _appcontext;
        public UserRepository(PostgresContext appcontext) : base(appcontext)
        {
            _appcontext= appcontext;
        }


        public async Task<Models.SupabaseModels.User1> GetCred(LoginDto cred)
        {
            IQueryable<Models.SupabaseModels.User1> cs = _appcontext.Users1.Where(u => u.Email == cred.Email);

            Models.SupabaseModels.User1 found_user = await cs.FirstAsync();

            if (found_user != null)
            {
                return found_user;
            }
            else
            {
                throw new InvalidOperationException("User not found or invalid password.");
            }
        }


        public async Task<long> GetUserID(string mail)
        {
            IQueryable<Models.SupabaseModels.User1> cs=_appcontext.Users1.Where(u=>u.Email == mail);

            Models.SupabaseModels.User1 found_user = await cs.FirstAsync();
            return found_user.Userid;

        }
    }
    }

