using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Services.Factories;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Interfaces.Services.Utilites;
using BusinessLogic.Services.Generic;
using BusinessLogic.Services.PaymentService.StripeService;
using BusinessLogic.Services.ProductService;
using BusinessLogic.Services.RoleService;
using BusinessLogic.Services.UserService;
using BusinessLogic.Services.Utilities.Factories.User;
using BusinessLogic.Services.Utilities.FileStorage;
using BusinessLogic.Services.Utilities.Identity.Authenticator;
using BusinessLogic.Services.Utilities.Mapper;
using DataAccess.Repositories;
using DataAccess.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.IdentityModel.Tokens;
using Models.SupabaseModels;
using Stripe;
using System.Net;
using System.Text;
using BusinessLogic.Interfaces.Services.GenericService;
using BusinessLogic.Interfaces.Services.UserService;
using BusinessLogic.Interfaces.Services.StripService;
using BusinessLogic.Interfaces.Services.RoleService;
using BusinessLogic.Interfaces.Services.AddressService;
using BusinessLogic.Interfaces.Services.CheckoutService;
using BusinessLogic.Interfaces.Services.Order;
using BusinessLogic.Services.AddressService;
using BusinessLogic.Services.CheckoutService;
using BusinessLogic.Services.Order;
using BusinessLogic.Services.Utilities.Factories.Address;
using BusinessLogic.Services.Utilities.Factories.Payment;
using BusinessLogic.Services.ProductSizeService;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin() 
               .AllowAnyMethod() 
               .AllowAnyHeader(); 
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAyesha", builder =>
    {
        builder.WithOrigins("https://www.ayeshaalidesign.com")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

IConfiguration config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
var Config = config.GetSection("Jwt");
var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Config["Key"]!));
builder.Services.AddAuthentication(options =>
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

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductSizeRepository, ProductSizeRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IProductService, BusinessLogic.Services.ProductService.ProductService>();
builder.Services.AddScoped<IOrderItemService, OrderItemService>();
builder.Services.AddScoped<ICheckoutService, CheckoutService>();
builder.Services.AddScoped<IProductSizeService, ProductSizeService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserFactory, UserFactory>();
builder.Services.AddScoped<IPaymentFactory, PaymentFactory>();
builder.Services.AddScoped<IAddressFactory, AddressFactory>();
builder.Services.AddTransient<IStripeService, StripeService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddDbContext<PostgresContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var portExists = int.TryParse(Environment.GetEnvironmentVariable("PORT"), out var port);
if (portExists)
{
    builder.WebHost.ConfigureKestrel(options =>
    {
        options.ListenAnyIP(port);
    });
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/", () => "Server is running.Dev");


app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.UseCors("AllowAyesha");


app.MapControllers();

app.Run();
