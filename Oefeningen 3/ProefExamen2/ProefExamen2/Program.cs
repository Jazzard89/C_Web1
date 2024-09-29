using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProefExamen2.Data;
using ProefExamen2.Data.DefaultData;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//connectionstring
var ConnString = builder.Configuration.GetConnectionString("ConnString");
//DbContext
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(ConnString));
//Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<AppDbContext>();
    //(options => 
    //options.SignIn.RequireConfirmedAccount = true
//).AddEntityFrameworkStores<AppDbContext>();






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

SeedData.EnsureCreatedAsync(app);

app.Run();
