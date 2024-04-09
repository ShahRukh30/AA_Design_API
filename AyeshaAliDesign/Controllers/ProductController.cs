using AutoMapper;
using BusinessLogic.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Product;
using System.Runtime.CompilerServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : SuperController<Product, ProductDto>
    {
        public ProductController(IGenericService<Product> gen, IMapper mapper) : base(gen, mapper)
        {
        }

        [HttpPost("Add")]

        public override async Task<ActionResult<Product>> Post([FromBody] ProductDto dto)
        {
            return new Product();
        }

    }
}
