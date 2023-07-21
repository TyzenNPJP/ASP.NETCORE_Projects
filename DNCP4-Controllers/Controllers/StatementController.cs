using Microsoft.AspNetCore.Mvc;

namespace DNCP4_Controllers.Controllers
{
    public class StatementController : Controller
    {
        [Route("/account-statement")]
        public IActionResult acc_statement()
        {
            if (Request.Method == "GET")
            {
                StatusCode(200);
                return File("Probability_MIT.pdf", "application/pdf");
            }
            else
            {
                return Content("Only Make GET Http requests");
            }
        }
    }
}
