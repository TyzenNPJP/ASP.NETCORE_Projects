/*
 * ABOUT -  HTTP REQUEST & RESPONSE HANDLER USING CONTROLLERS & ROUTING THEM
 *          @ UseRouting()
 *          @ UseEndpoints()
 *          @ endpoints.MapGet()
*/

Dictionary<int, string> nation_Dict = new Dictionary<int, string>()
{
    [1] = "United States",
    [2] = "Canada",
    [3] = "United Kingdom",
    [4] = "India",
    [5] = "Japan"
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

// Initalizes the use of routing and runs any endpoints below than this command
app.UseRouting();

// Initializes endpoints that respond to HTTP request in accordance
// Creates an object if HttpContext by default
app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("/Countries", async context =>
    {
        context.Response.StatusCode = 200;
        foreach (int i in nation_Dict.Keys)
        {
            await context.Response.WriteAsync($"{i}, {nation_Dict[i]}\n");
        }
    });

    // Route paramter constraints range
    endpoints.MapGet("/Countries/{id:int:range(1,100)}", async context =>
    {
        int id = Convert.ToInt32(context.Request.RouteValues["id"]);

        if (id >= 1 && id <= 5)
        {
            context.Response.StatusCode = 200;
            await context.Response.WriteAsync($"{nation_Dict[id]}\n");
        }
        else if (id >= 6 && id <= 100)
        {
            context.Response.StatusCode = 404;
            await context.Response.WriteAsync("[No Country]\n");
        }
    });

    // Route paramter constraint min
    endpoints.MapGet("/Countries/{id:int:min(101)}", async context =>
    {
        context.Response.StatusCode = 400;
        await context.Response.WriteAsync("The CountryID needs to be between 1 and 100.\n");
    });
});

app.Run(async context =>
{
    await context.Response.WriteAsync("Successfully exited.");
});

app.Run();