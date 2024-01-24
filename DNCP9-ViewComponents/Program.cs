var builder = WebApplication.CreateBuilder();

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseRouting();
app.UseStaticFiles();
app.MapControllers();

app.Run();