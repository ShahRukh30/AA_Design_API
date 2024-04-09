using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Interfaces.Services.Utilites;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BusinessLogic.Services.ProductService
{
    public class ProductService : IProductService
    {

        private readonly IProductSizeService _productsize;
        private readonly IProductImageService _productimage;
        private readonly IProductCategoryService _productcategory;
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Product> _gen;
        private readonly IFileStorageService _imageStore;
        public ProductService(IMapper mapper, IGenericRepository<Product> gen, IFileStorageService imageStore)
        {
            _mapper = mapper;
            _gen = gen;
            _imageStore = imageStore;
        }
        public Task Delete(Product Entity)
        {
            throw new NotImplementedException();
        }

        public Task<Product> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Product> Post(ProductDto Entity)
        {
            Product product= _mapper.Map<Product>(Entity);

            List<IFormFile> imgs = Entity.Images;
            foreach (IFormFile file in imgs)
            {
                _imageStore.UploadImageToBucket(file);
            }
            //_gen.Post(product);

            using (var scope = new TransactionScope())
            {
                

                scope.Complete(); 
            }
            return null;
        }

        public Task Put(Product Entity)
        {
            throw new NotImplementedException();
        }
    }
}
