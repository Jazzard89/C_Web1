using Microsoft.Extensions.FileProviders;
using System.Net.NetworkInformation;

var builder = WebApplication.CreateBuilder(args);

//We activate razorpages if we want to use Razorpages here
builder.Services.AddRazorPages();

var app = builder.Build();

//we comment this out
//app.MapGet("/", () => "Hello World!");


//this makes sure we can use the default files from the wwwroot folder, it uses
//default.html or index.html
app.UseDefaultFiles();


//this makes sure we can use the default CSS and JS files from the wwwroot folder
app.UseStaticFiles();


//We have to specify where the adress of the pages is located at
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(app.Environment.ContentRootPath, "Pages")), RequestPath = "/Pages"
});

//If we use this we can no longer use hmtl pages and the default
//page will be index.cshmtl instead of default.html
app.MapRazorPages();


app.Run();
