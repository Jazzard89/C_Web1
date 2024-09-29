using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcGroentenEnFruit2024_2.Data;
using MvcGroentenEnFruit2024_2.Data.DefaultData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//connectionstring
var connString = builder.Configuration.GetConnectionString("ConnString");
//Entity Framework
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connString));
//Identity Framework
builder.Services.AddIdentity<IdentityUser, IdentityRole>(
    //options => options.SignIn.RequireConfirmedAccount = true
    )
    .AddEntityFrameworkStores<AppDbContext>();
//end


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

SeedData.EnsurePopulatedAsync(app);
app.Run();
