using AutoMapper;
using FinalWebApp.Context;
using FinalWebApp.Controllers;
using FinalWebApp.Mappers;
using FinalWebApp.Repositories;
using FinalWebApp.Repositories.Interfaces;
using FinalWebApp.Services;
using FinalWebApp.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebDatabase"));
});

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.WriteIndented = true;
});

//register mapper 
var mapperConfig = new MapperConfiguration(mp =>
{
    mp.AddProfile(new CategoryMapperProfile());
    mp.AddProfile(new ProductMapperProfile());
});
builder.Services.AddSingleton(mapperConfig.CreateMapper());

//register service 
builder.Services.AddScoped<ICategoryService, CategoryService>();

// register repository
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHttpLogging(options =>
{
    options.LoggingFields = Microsoft.AspNetCore.HttpLogging.HttpLoggingFields.All;
});

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpLogging();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
