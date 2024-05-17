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
using API.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration)
    .AddApplication(builder.Configuration)
    .AddAPI(builder.Configuration);


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
