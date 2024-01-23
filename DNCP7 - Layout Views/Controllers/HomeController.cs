using Microsoft.AspNetCore.Mvc;

namespace DNCP7___Layout_Views.Controllers
{
    public class HomeController : Controller
    {
        [Route("/")]
        public IActionResult Home()
        {
            return View("Home");
        }

        [Route("/about-page")]
        public IActionResult About()
        {
            return View("About");
        }
    }
}
