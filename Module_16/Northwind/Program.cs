using DataAccess;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Northwind.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<IRepository<ProductEntity>, ProductRepository<ProductEntity>>();
builder.Services.AddTransient<IRepository<CategoryEntity>, CategoryRepository<CategoryEntity>>();
builder.Services.AddTransient<IRepository<SupplierEntity>, SupplierRepository<SupplierEntity>>();

builder.Services.AddTransient<HomeService>();

builder.Services.AddDbContext<NorthwindContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("NorthwindContext")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
