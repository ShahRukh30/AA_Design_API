using AutoMapper;
using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Interfaces.Services.Utilites;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Models.SupabaseModels;
using Models.SupabaseModels.Common;
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
        private readonly IProductRepository _productrepo;
        public ProductService(IMapper mapper, IGenericRepository<Product> gen, IFileStorageService imageStore,
            IProductImageService productimage,IProductSizeService productSize, IProductRepository productrepo)
        {
            _mapper = mapper;
            _gen = gen;
            _imageStore = imageStore;
            _productimage = productimage;
            _productsize = productSize;
            _productrepo = productrepo;
        }
      

        public async Task<object> GetDetailsbyID(int id)
        {
            return await _productrepo.GetDetailsById(id);
        }

        public async Task<IEnumerable<object>> GetProductListing()
        {
            return await _productrepo.GetProductListing();
        }
        public async Task<Product> Post(ProductDto Entity)
        {
            Product product= _mapper.Map<Product>(Entity);
            product.Quantity=Entity.XLQuantity+Entity.LQuantity+Entity.MQuantity+Entity.SQuantity+Entity.XSQuantity;

            Product p=await _gen.Post(product);
            List<IFormFile> imgs = Entity.Images;
            bool isFirstImage = true;
            foreach (IFormFile file in imgs)
            {

                string imgurl = await _imageStore.UploadImageToBucket(file).ConfigureAwait(false);

                // Create a new ProductImageDto for mapping
                ProductImageDto imagedto = new ProductImageDto
                {
                    Imagename = p.Productname,
                    Imageurl = imgurl,
                    Productid = p.Productid,
                    Ismainimage = isFirstImage  // Set Ismainimage based on isFirstImage flag
                };

                // Map ProductImageDto to Productimage entity using AutoMapper
                Productimage finalimg = _mapper.Map<Productimage>(imagedto);

                // Post the final Productimage entity to the database
                await _productimage.post(finalimg).ConfigureAwait(false);

                // After processing the first image, set isFirstImage flag to false
                isFirstImage = false;
            }
            ProductSizeDto sizedto = new ProductSizeDto();
            sizedto.Productid=p.Productid;


            if (Entity.XLQuantity > 0)
            {
                EnumSize size = EnumSize.XL;
                sizedto.Sizeid = ((int)size);
                sizedto.Sizequantity = Entity.XLQuantity;
                Productsize finalsize = _mapper.Map<Productsize>(sizedto);
               await _productsize.post(finalsize);
            }
            if (Entity.LQuantity > 0)
            {
                EnumSize size = EnumSize.L;
                sizedto.Sizeid = ((int)size);
                sizedto.Sizequantity = Entity.LQuantity;
                Productsize finalsize = _mapper.Map<Productsize>(sizedto);
                await _productsize.post(finalsize);
            }
            if (Entity.MQuantity > 0)
            {
                EnumSize size = EnumSize.M;
                sizedto.Sizeid = ((int)size);
                sizedto.Sizequantity = Entity.MQuantity;
                Productsize finalsize = _mapper.Map<Productsize>(sizedto);
                await _productsize.post(finalsize);
            }

            if (Entity.SQuantity > 0)
            {
                EnumSize size = EnumSize.S;
                sizedto.Sizeid = ((int)size);
                sizedto.Sizequantity = Entity.SQuantity;
                Productsize finalsize = _mapper.Map<Productsize>(sizedto);
                await _productsize.post(finalsize);
            }
            if (Entity.XSQuantity > 0)
            {
                EnumSize size = EnumSize.XS;
                sizedto.Sizeid = ((int)size);
                sizedto.Sizequantity = Entity.XSQuantity;
                Productsize finalsize = _mapper.Map<Productsize>(sizedto);
                await _productsize.post(finalsize);
            }



            return product;
        }

       
    }
}
