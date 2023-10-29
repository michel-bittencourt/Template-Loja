using Loja.Application.DTO;
using Loja.Application.Mappings;
using Loja.Application.Services.Inventory;
using Loja.Application.Services.Products;
using Loja.Domain.Entities;
using Loja.Domain.Interfaces;
using Loja.Domain.Repositories;
using Loja.Infrastructure.Data.Contexts;
using Loja.Infrastructure.Repositories;
using Loja.WebAPI.Controllers;
using Microsoft.OpenApi.Models;
using System.ComponentModel;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddNewtonsoftJson(x =>
    {
        x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
    });
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddAutoMapper(typeof(DomainToDTOMappingProfile));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors();
builder.Services.AddSqlServer<ApplicationDbContext>(builder.Configuration["ConnectionStrings:Default"]);
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Loja.WebAPI",
        Version = "v1",
        Contact = new OpenApiContact
        {
            //Name = "Name",
            //Email = "",
            //Url = new Uri("site"),
        }
    });

    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(c =>
{
    c.AllowAnyOrigin();
    c.AllowAnyHeader();
    c.AllowAnyMethod();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
