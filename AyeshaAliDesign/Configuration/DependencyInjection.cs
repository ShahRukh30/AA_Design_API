using BusinessLogic.Interfaces.Repositories;
using DataAccess.Repositories;
using Infrastructure.Repositories.Generic;
using Infrastructure.Repositories;
using DataAccess.Context;
using BusinessLogic.Interfaces.Services.AddressService;
using BusinessLogic.Interfaces.Services.CheckoutService;
using BusinessLogic.Interfaces.Services.Factories;
using BusinessLogic.Interfaces.Services.GenericService;
using BusinessLogic.Interfaces.Services.Order;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Interfaces.Services.RoleService;
using BusinessLogic.Interfaces.Services.StripService;
using BusinessLogic.Interfaces.Services.UserService;
using BusinessLogic.Interfaces.Services.Utilites;
using BusinessLogic.Services.AddressService;
using BusinessLogic.Services.CheckoutService;
using BusinessLogic.Services.Generic;
using BusinessLogic.Services.Order;
using BusinessLogic.Services.PaymentService.StripeService;
using BusinessLogic.Services.ProductService;
using BusinessLogic.Services.ProductSizeService;
using BusinessLogic.Services.RoleService;
using BusinessLogic.Services.UserService;
using BusinessLogic.Services.Utilities.Factories.Address;
using BusinessLogic.Services.Utilities.Factories.Payment;
using BusinessLogic.Services.Utilities.Factories.User;
using BusinessLogic.Services.Utilities.FileStorage;
using BusinessLogic.Services.Utilities.Mapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Configuration
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration config)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepo<>));
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<PostgresContext>();
            return services;

        }

        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration config)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
            services.AddScoped<IProductService, BusinessLogic.Services.ProductService.ProductService>();
            services.AddScoped<IOrderItemService, OrderItemService>();
            services.AddScoped<ICheckoutService, CheckoutService>();
            services.AddScoped<IProductSizeService, ProductSizeService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserFactory, UserFactory>();
            services.AddScoped<IPaymentFactory, PaymentFactory>();
            services.AddScoped<IAddressFactory, AddressFactory>();
            services.AddTransient<IStripeService, StripeService>();
            services.AddScoped<IAddressService, AddressService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<IRoleService, RoleService>();
            return services;

        }


        public static IServiceCollection AddAPI (this IServiceCollection services,IConfiguration config)
        {
            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
             ); ;
            
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", builder =>
                {
                    builder.AllowAnyOrigin()
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

           services.AddCors(options =>
            {
                options.AddPolicy("AllowAyesha", builder =>
                {
                    builder.WithOrigins("https://www.ayeshaalidesign.com/")
                           .AllowAnyMethod()
                           .AllowAnyHeader();
                });
            });

            config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var Config = config.GetSection("Jwt");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Key"]!));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Config["Issuer"],
                    ValidAudience = Config["Audience"],
                    IssuerSigningKey = key
                };
            });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;

        }

    }
}
