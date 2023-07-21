/*
 * ABOUT -  MIDDLEWARES EXTENSION CLASS
 *          @ UseMiddlewareExt()
 *          @ Invoke()
*/
using Udemy_Assignment6;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Places a middleware extension in this spot
app.UseMiddlewareExt();

app.Run(async (HttpContext context) =>
{
    await context.Response.WriteAsync("Process complete!\n");
});

app.Run();
