using BusinessLogic.Interfaces.Repositories;
using BusinessLogic.Interfaces.Services;
using BusinessLogic.Interfaces.Services.Product;
using BusinessLogic.Interfaces.Services.Utilites;
using BusinessLogic.Services.Generic;
using BusinessLogic.Services.ProductService;
using BusinessLogic.Services.RoleService;
using BusinessLogic.Services.Utilities.FileStorage;
using BusinessLogic.Services.Utilities.Mapper;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Generic;
using Models.SupabaseModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
); ;
//builder.Services.AddCors(options =>
//{
//    options.AddDefaultPolicy(builder =>
//    {
//        builder.AllowAnyOrigin() // Allow requests from any origin
//               .AllowAnyMethod() // Allow all HTTP methods
//               .AllowAnyHeader(); // Allow all headers
//    });
//});

builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepo<>));
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductSizeService,ProductSizeService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IFileStorageService, FileStorageService>();
builder.Services.AddScoped<IRoleService,RoleService>();
builder.Services.AddDbContext<PostgresContext>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
