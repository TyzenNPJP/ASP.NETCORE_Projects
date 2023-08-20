/*
 * ABOUT -  CONTROLLERS, MODEL BINDING, MODEL VALIDATION ATTRIBUTE
 *       -  An ecommerce app of buying products and making orders
 *          
 *          @ ValidationAttribute
 *          @ [Range()]
 *          @ IActionResult
 *          @ BadRequest()
*/

var builder = WebApplication.CreateBuilder(args);
// Configures controllers with required setup to run
builder.Services.AddControllers();

var app = builder.Build();

app.MapGet("/", () => "Welcome to the store!");

// Initiates all controllers
app.MapControllers();

app.Run();
