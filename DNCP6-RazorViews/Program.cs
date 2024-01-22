/*
 *  ABOUT -     WEATHER APP THAT SHOWS CITY DETAILS AND WEATHER
*/

var builder = WebApplication.CreateBuilder();

// Configures the bulid with controllers and view page
builder.Services.AddControllersWithViews();

var app = builder.Build();

app.MapControllers();

app.UseStaticFiles();

app.Run();