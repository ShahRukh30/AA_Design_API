using BusinessLogic.Interfaces.Services.Factories;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Utilities.Factories.User
{
    public class UserFactory:IUserFactory
    {
        public User1 CreateUser(User1 users) {
            User1 user = new User1
            {
               Firstname=users.Firstname,
               Lastname=users.Lastname,
               Email=users.Email,
               Phone = users.Phone,
               Roleid=2

            };

            user.Isactive = false;

            return user;
        }

    }
}
