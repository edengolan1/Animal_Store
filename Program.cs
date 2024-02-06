using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProjectAspNet.Data;
using ProjectAspNet.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddTransient<IRepository, MyRepository>();
var connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"]!;
builder.Services.AddDbContext<AnimalContext>(option => option.UseLazyLoadingProxies().UseSqlServer(connectionString));
builder.Services.AddDbContext<AuthenticationContext>(option => option.UseSqlite("Data Source=c:\\Asp.net\\Project\\ProjectAnimals\\ProjectAspNet\\users.db"));
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AuthenticationContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();
app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AnimalContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
using (var scope = app.Services.CreateScope())
{
    var ctx = scope.ServiceProvider.GetRequiredService<AuthenticationContext>();
    ctx.Database.EnsureDeleted();
    ctx.Database.EnsureCreated();
}
app.UseAuthentication();
app.UseRouting();
app.MapControllerRoute("default", "{controller=Animal}/{action=Index}");
app.Run();