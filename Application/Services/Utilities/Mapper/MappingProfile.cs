using AutoMapper;
using Models.SupabaseModels;
using Models.SupabaseModels.Dto;
using Models.SupabaseModels.Dto.Order;
using Models.SupabaseModels.Dto.Product;
using Models.SupabaseModels.Dto.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services.Utilities.Mapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Role, RoleDto>();
            CreateMap<RoleDto, Role>();
            CreateMap<ProductDto, Product>();
            CreateMap<Product, ProductDto>();
            CreateMap<Productimage, ProductImageDto>();
            CreateMap<ProductImageDto, Productimage>();
            CreateMap<ProductSizeDto, Productsize>();
            CreateMap<Productsize, ProductSizeDto>();
            CreateMap<User1, UserDto>();
            CreateMap<UserDto, User1>();
            CreateMap<OrderDto, Models.SupabaseModels.Order>();
            CreateMap<Models.SupabaseModels.Order, OrderDto>();
            CreateMap<Orderitem, OrderItemDto>();
            CreateMap<OrderItemDto, Orderitem>();
            


        }
    }
}
