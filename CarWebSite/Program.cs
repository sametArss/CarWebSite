using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

using DataAcsessLayer.Concrete.Context; 


var builder = WebApplication.CreateBuilder(args);

// PostgreSQL baðlantýsýný burada tanýmlýyoruz
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Controller ve View servisini ekliyoruz
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Hatalarý ve güvenliði ayarlýyoruz
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Default route
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
