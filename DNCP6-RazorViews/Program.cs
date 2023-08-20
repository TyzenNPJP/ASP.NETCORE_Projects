/*
 *  ABOUT -     WEATHER APP THAT SHOWS CITY DETAILS AND WEATHER
*/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStaticFiles();

app.MapControllers();

app.Run();
