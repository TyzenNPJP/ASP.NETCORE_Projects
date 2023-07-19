/*
 * ABOUT :  @ HTTP REQUEST / HTTP RESPONSE 
 *          @ URL MANIPULATION
 *          @ ACTION METHODS
 *          @ STATUS CODES
*/

// Creates an primary object of web application
var builder = WebApplication.CreateBuilder();
// Creates an object with which HTTP request and response is handled
var app = builder.Build();

// Executes a function that handles HTTP request and response
app.Run(async (HttpContext context) =>
{
    // Checks the action method and default path
    if (context.Request.Method == "GET" && context.Request.Path == "/")
    {
        int num1 = 0;
        int num2 = 0;
        string? operation = null;
        int? result = null;

        // Checks the query for URL variables
        if (context.Request.Query.ContainsKey("num1"))
        {
            string strNum1 = context.Request.Query["num1"][0];
            if (!string.IsNullOrEmpty(strNum1))
            {
                num1 = Convert.ToInt32(context.Request.Query["num1"][0]);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for num1!");
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;

            await context.Response.WriteAsync("Invalid query!");
        }

        // Checks the query for URL variables
        if (context.Request.Query.ContainsKey("num2"))
        {
            string strNum2 = context.Request.Query["num2"][0];
            if (!string.IsNullOrEmpty(strNum2))
            {
                num1 = Convert.ToInt32(context.Request.Query["num2"][0]);
            }
            else
            {
                context.Response.StatusCode = 400;
                await context.Response.WriteAsync("Invalid input for num2!");
            }
        }
        else
        {
            if (context.Response.StatusCode == 200)
                context.Response.StatusCode = 400;

            await context.Response.WriteAsync("Invalid Query!");
        }

        // Checks the query for URL variables
        if (context.Request.Query.ContainsKey("operator"))
        {
            operation = Convert.ToString(context.Request.Query["operator"][0]);
            if (!string.IsNullOrEmpty(operation))
            {
                switch (operation)
                {
                    case "add": result = (num1 + num2); break;
                    case "subtract": result = (num2 - num1); break;
                    case "multiply": result = (num1 * num2); break;
                    case "divide": result = (num2 != 0) ? (num1 / num2) : 0; break;
                    case "mod": result = (num2 != 0) ? (num1 % num2) : 0; break;
                }

                if (result.HasValue)
                {
                    context.Response.StatusCode = 200;
                    await context.Response.WriteAsync("Result: " + result.Value.ToString());
                }
                else
                {
                    if (context.Response.StatusCode == 200)
                        context.Response.StatusCode = 400;

                    await context.Response.WriteAsync("Invalid Query!");
                }
            }
            else
            {
                if (context.Response.StatusCode == 200)
                    context.Response.StatusCode = 400;

                await context.Response.WriteAsync("Invalid input for operator!");
            }
        }
    }
});

app.Run();
