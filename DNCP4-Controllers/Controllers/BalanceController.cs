using Microsoft.AspNetCore.Mvc;

namespace DNCP4_Controllers.Controllers
{
    public class BalanceController : Controller
    {
        [Route("/get-account-balance")]
        public IActionResult acc_balance1()
        {
            StatusCode(404);
            return Content("Account Number should be supplied");
        }

        [Route("/get-account-balance/{accNum:int}")]
        public IActionResult acc_balance2()
        {
            var accNum = Convert.ToInt32(Request.RouteValues["accNum"]);

            if (accNum == 1001)
            {
                StatusCode(200);
                return Content($"<h1>Valid accNum! {accNum} has a balance of 5000</h1>");
            }
            else
            {
                return BadRequest("Account number should be 1001");
            }
        }
    }
}
