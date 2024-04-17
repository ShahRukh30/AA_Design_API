using AutoMapper;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Services.ProductService;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Product;
using System.Runtime.CompilerServices;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class ProductController : ControllerBase
    {
        private  readonly IProductService _product;
        public ProductController(IProductService product)
        {
            _product=product;
        }

        [HttpPost("Add")]

        public async Task<ActionResult<Product>> Post([FromForm] ProductDto dto)
        {
            return await _product.Post(dto);    
        }

        [HttpGet]

        public async Task<IEnumerable<object>> Get()
        {
            return await _product.GetProductListing();
        }



        [HttpGet("{id}")]

        public async Task<object> GetDetailsById(int id)
        {
            return await _product.GetDetailsbyID(id);
        }

    }
}
