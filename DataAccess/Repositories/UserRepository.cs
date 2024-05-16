using BusinessLogic.Interfaces.Repositories;
using DataAccess.Context;
using Infrastructure.Repositories.Generic;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using Newtonsoft.Json;
using Supabase.Gotrue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class UserRepository : GenericRepo<User1>, IUserRepository
    {
        private readonly PostgresContext _appcontext;
        public UserRepository(PostgresContext appcontext) : base(appcontext)
        {
            _appcontext = appcontext;
        }


        public async Task<User1> GetCred(LoginDto cred)
        {
            IQueryable<User1> cs = _appcontext.Users1.Where(u => u.Email == cred.Email);

            User1 found_user = await cs.FirstAsync();

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
            IQueryable<Models.SupabaseModels.User1> cs = _appcontext.Users1.Where(u => u.Email == mail);

            Models.SupabaseModels.User1 found_user = await cs.FirstOrDefaultAsync();
            if (found_user == null){
                return 0;
            }
            return found_user.Userid;

        }

        public async Task<long> CreateUser(User1 user)
        {
            var url = "https://lbqpoifccgmqlsydhvke.supabase.co";
            var key = "";
            var options = new Supabase.SupabaseOptions
            {
                AutoConnectRealtime = true
            };

            var supabase = new Supabase.Client(url, key, options);
            await supabase.InitializeAsync();

            var functionName = "postuserdto"; // Adjusted function name                                                                                                                    // Prepare function arguments matching your function definition
            var arguments = new Dictionary<string, object>()
            {
                { "first_name", user.Firstname },
                { "last_name", user.Lastname },
                { "email", user.Email },
                { "phone", user.Phone }, 
                { "is_active", user.Isactive }
                 };

            var response = await supabase.Rpc(functionName, arguments);

            var details = JsonConvert.DeserializeObject<long>(response.Content);
            return details;


        }

    }
}

