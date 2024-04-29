using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Interfaces.Services.RoleService
{
    public interface IRoleService
    {
        Task<IEnumerable<Role>> Get();
    }
}
