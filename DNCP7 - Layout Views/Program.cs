// A company web app with layout views
// Home page, About page
// Employee dashboard page, Employer dashboard page

var builder = WebApplication.CreateBuilder();
builder.Services.AddControllersWithViews();
var app = builder.Build();
app.UseRouting();
app.MapControllers();
app.Run();