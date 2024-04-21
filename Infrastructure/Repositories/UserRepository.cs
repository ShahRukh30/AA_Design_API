using BusinessLogic.Interfaces.Repositories;
using Infrastructure.Context;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgresContext _context;

        public UserRepository(PostgresContext context)
        {
            _context = context;
        }

        public async void RegisterDto(User1 user)
        {
            
                await _context.Users1.AddAsync(user);
                await _context.SaveChangesAsync();
               
            
           
        }
    }
}
