using Microsoft.EntityFrameworkCore;
using PdpLesson09.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Lấy đúng tên chuỗi kết nối trong appsettings.json
var connectionString = builder.Configuration.GetConnectionString("PdpBookStore");

builder.Services.AddDbContext<PdpBookStoreContext>(x =>
    x.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PdpCategories}/{action=PdpIndex}/{id?}");

app.Run();
