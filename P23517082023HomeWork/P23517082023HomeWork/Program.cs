using Microsoft.EntityFrameworkCore;
using P23517082023HomeWork.DataAccessLayer;

var builder = WebApplication.CreateBuilder(args);
//string con = builder.Configuration.GetConnectionString("Default");
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options => options
    .UseSqlServer(/*con*/builder.Configuration.GetConnectionString("Default")));
var app = builder.Build();

app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

app.Run();