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
using Microsoft.AspNetCore.Hosting;
using Models.SupabaseModels;
using System.Net;

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
app.MapGet("/", () => "Server is running!");


app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors("AllowAll");

app.MapControllers();

app.Run();
