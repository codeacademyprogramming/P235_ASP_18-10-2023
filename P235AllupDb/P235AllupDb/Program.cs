using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using P235AllupDb.DataAccessLayer;
using P235AllupDb.Interfaces;
using P235AllupDb.Models;
using P235AllupDb.Services;
using P235AllupDb.ViewModels;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

    options.Password.RequiredLength = 8;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireDigit = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = true;

    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 5;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
}).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

builder.Services.Configure<SmtpSetting>(builder.Configuration.GetSection("SmtpSetting"));

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    //options.Cookie.Expiration = TimeSpan.FromSeconds(5);
});

builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ILayoutService,LayoutService>();
//builder.Services.AddTransient<>
//builder.Services.AddSingleton<>
//builder.Services.AddScoped<>

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();
app.UseSession();
app.MapControllerRoute("area", "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");
app.MapControllerRoute("Default", "{controller=Home}/{action=Index}/{id?}");

app.Run();