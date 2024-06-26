﻿using AutoMapper;
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
        private readonly IProductSizeService _size;
        public ProductController(IProductService product, IProductSizeService size)
        {
            _product=product;
            _size = size;
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

        [HttpGet("size/{id}")]

        public async Task<List<string>> GetSizes(long id)
        {
            return await _size.GetAvailableSizes(id);
        }

    }
}
