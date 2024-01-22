/*
 * ABOUT - CONTROLLERS - A banking app that collects account profile and responds with files and content
 *              
 *                          (Collect data from HTTP requests,
 *                          Perform operation on data through models and
 *                          Render views on HTML web pages)
 *                          
 *          @ AddControllers()
 *          @ UseRouting()
 *          @ UseStaticFiles()
 *          @ ContentResult
 *          @ IActionResult
 *          @ FILE
 *          @ Content
*/

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

app.UseRouting();

app.MapControllers();

// Allows use of files that are in the 'wwwroot' folder 
app.UseStaticFiles();

app.Run();
