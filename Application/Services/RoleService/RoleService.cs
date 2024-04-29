using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.RoleService;
using Models.SupabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.RoleService
{
    public class RoleService:IRoleService
    {
        private readonly IGenericRepository<Role> _repository;
        public RoleService(IGenericRepository<Role> repository)
        {
            _repository = repository;
            
        }
        public Task<IEnumerable<Role>> Get()
        {
            return _repository.Get();
        }
    }
}
