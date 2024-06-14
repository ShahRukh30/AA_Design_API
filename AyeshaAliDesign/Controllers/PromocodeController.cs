using AutoMapper;
using BusinessLogic.Interfaces.Services.GenericService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Promocode;
using System.Runtime.CompilerServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromocodeController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IGenericService<Promocode> _genericService;
        public PromocodeController(IMapper mapper, IGenericService<Promocode> genericService)
        {
            _mapper = mapper;
            _genericService=genericService;
        }


        [HttpPost]

        public async Task<Promocode> Post(PromocodeDto dto)
        {
            Promocode a= _mapper.Map<Promocode>(dto);
           return await _genericService.post(a);

        }
    }
}
