using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.Factories
{
    public interface IUserFactory
    {
        public User1 CreateUser(User1 users);
    }
}
