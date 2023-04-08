using BTL_ConGa.Models;
using BTL_ConGa.Repository;
using BTL_ConGa.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
var connectionString = builder.Configuration.GetConnectionString("BtlWebContext");
builder.Services.AddDbContext<BtlWebContext>(x => x.UseSqlServer(connectionString));
builder.Services.AddScoped<IDanhMucSPRepository, DanhMucSPRepository>();
builder.Services.AddScoped<IUserInforService, UserInforService>();
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
    pattern: "{controller=TrangChu}/{action=TrangChu}/{id?}");

app.Run();
