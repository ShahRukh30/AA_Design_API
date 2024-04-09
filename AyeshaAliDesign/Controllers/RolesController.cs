using AutoMapper;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : SuperController<Role, RoleDto>
    {
        public RolesController(IGenericService<Role> gen, IMapper mapper) : base(gen, mapper)
        {
        }
    }
}
