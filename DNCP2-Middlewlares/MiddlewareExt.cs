using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace Udemy_Assignment6
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class MiddlewareExt
    {
        private bool validatePassword(string password)
        {
            return password.Any(ch => !char.IsLetterOrDigit(ch));
        }

        private readonly RequestDelegate _next;

        // Passes on to the next middleware in line
        public MiddlewareExt(RequestDelegate next)
        {
            _next = next;
        }

        // Input manual validation
        public async Task Invoke(HttpContext httpContext)
        {
            string email = "";
            string password = "";
            string emailPattern = "@example.com";
            bool isCorrectEmail = false;
            bool isCorrectPassword = false;

            if (httpContext.Request.Query.ContainsKey("email") && httpContext.Request.Query.ContainsKey("password"))
            {
                email = httpContext.Request.Query["email"][0];
                if (email.EndsWith(emailPattern))
                {
                    isCorrectEmail = true;
                }

                password = httpContext.Request.Query["password"][0];
                if (validatePassword(password) == false)
                {
                    isCorrectPassword = true;
                }

                if (isCorrectEmail && isCorrectPassword)
                {
                    httpContext.Response.StatusCode = 200;
                    await httpContext.Response.WriteAsync("Successful Login!\nYou are logged in as " + email + "\n");
                }

                if (!isCorrectEmail && !isCorrectPassword)
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid Email & Password!\n");
                }
                else if (!isCorrectEmail)
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid Email!\n");
                }
                else if (!isCorrectPassword)
                {
                    httpContext.Response.StatusCode = 400;
                    await httpContext.Response.WriteAsync("Invalid Password!\n");
                }
            }
            else
            {
                httpContext.Response.StatusCode = 400;
                await httpContext.Response.WriteAsync("No email or password!\n");
            }

            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtExtensions
    {
        public static IApplicationBuilder UseMiddlewareExt(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MiddlewareExt>();
        }
    }
}
