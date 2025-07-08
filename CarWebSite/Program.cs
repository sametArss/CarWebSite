using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using DataAcsessLayer.Concrete.Context;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.EntityFramework;
using BusiniessLayer.Abstract;
using BusiniessLayer.Concrete;

var builder = WebApplication.CreateBuilder(args);

// ✅ PostgreSQL bağlantısı
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Repository (Data Access Layer) kayıtları
builder.Services.AddScoped<ICarsDal, EFCarsDal>();

// ✅ Service (Business Layer) kayıtları
builder.Services.AddScoped<ICarsService, CarsManager>();

// ✅ MVC Controller ve View servisi
builder.Services.AddControllersWithViews();

var app = builder.Build();

// ✅ Hata ve güvenlik ayarları
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// ✅ Varsayılan route ayarı
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
