using Microsoft.AspNetCore.Mvc;

namespace DNCP4_Controllers.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public ContentResult home()
        {
            if (Request.Method == "GET")
            {
                Response.StatusCode = 200;
                return Content("Welcome to the best bank!");
            }
            else
            {
                return Content("Only Make GET Http requests");
            }
        }
    }
}
