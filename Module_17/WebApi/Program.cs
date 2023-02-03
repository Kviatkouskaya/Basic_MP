using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using WebApi.Repository;
using WebApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddTransient<CategoryService>();
builder.Services.AddTransient<IRepository<Category>, CategoryRepository<Category>>();

builder.Services.AddTransient<ProductService>();
builder.Services.AddTransient<IRepository<Product>, ProductRepository<Product>>();

builder.Services.AddDbContext<WebApiContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

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
