using Microsoft.AspNetCore.Mvc;

namespace DNCP7___Layout_Views.Controllers
{
    public class EmployeeController : Controller
    {
        [Route("/employee-detail")]
        public IActionResult EmployeeDetail()
        {
            return View("EmployeeDetail");
        }

        [Route("/employer-detail")]
        public IActionResult EmployerDetail()
        {
            return View("EmployerDetail");
        }
    }
}
