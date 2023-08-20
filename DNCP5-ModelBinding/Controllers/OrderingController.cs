using Microsoft.AspNetCore.Mvc;
using DNCP5_ModelBinding.Models;

namespace DNCP5_ModelBinding.Controllers
{
    public class OrderingController : Controller
    {
        [HttpPost("/Orders")]
        public IActionResult Index()
        {
            if (!ModelState.IsValid)
            {
                string error = string.Join("\n", ModelState.Values.SelectMany(value => value.Errors).Select(Error => Error.ErrorMessage));
                return BadRequest(error);
            }
            else
            {
                if (Order.is_transaction_valid)
                {
                    StatusCode(200);
                    return Content($"Successful Transaction");
                }
                else
                {
                    return BadRequest($"Invalid invoice price! because invoice price is {Order.temp_invoice_price} {Order.temp_random}");
                }
            }
        }
    }
}
