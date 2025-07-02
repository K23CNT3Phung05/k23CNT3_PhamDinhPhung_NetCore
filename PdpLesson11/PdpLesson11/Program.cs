using Microsoft.EntityFrameworkCore;
using PhamDinhPhung_2310900083.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<PhamDinhPhung2310900083Context>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Middleware pipeline
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
    name: "employee_alias",
    pattern: "PdpEmployee/{action=PdpIndex}/{PdpId?}",
    defaults: new { controller = "PdpEmployee" });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=PdpHome}/{action=PdpIndex}/{id?}");

app.Run();
