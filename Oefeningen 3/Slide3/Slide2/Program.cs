using Slide2.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddRazorPages();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
//We voegen dit toe op de databank te starten
Databank.StartDatabank();

app.Run();
