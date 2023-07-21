using Microsoft.AspNetCore.Mvc;

namespace DNCP4_Controllers.Controllers
{
    public class DetailController : Controller
    {
        [Route("/account-details")]
        public IActionResult acc_details()
        {
            if (Request.Method == "GET")
            {
                return Json(new
                {
                    accNumber = 1001,
                    accHolderName = "Scruz",
                    accBalance = 5000000
                });
            }
            else
            {
                return Content("Only Make GET Http requests");
            }
        }
    }
}
