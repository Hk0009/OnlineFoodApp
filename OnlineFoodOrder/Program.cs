using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrder.Models;
using OnlineFoodOrder.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<foodieContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Connstr"));
});
builder.Services.AddDbContext<AppSecurityContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecurityConnStr"));
});
builder.Services.AddDefaultIdentity<IdentityUser>().AddEntityFrameworkStores<AppSecurityContext>().AddDefaultUI();

builder.Services.AddScoped<AuthService>();
builder.Services.AddScoped<IServices<RestaurantInfo, int>, RestaurantService>();
builder.Services.AddScoped<IServices<FoodCategory, int>, CategoriesServices>();
builder.Services.AddScoped<IServices<Product, int>, ProductServices>();

builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});
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
app.UseSession();
app.UseAuthentication();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
