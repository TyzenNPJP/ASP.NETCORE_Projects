using Microsoft.AspNetCore.Mvc;
using DNCP5_ModelBinding.Models;

namespace DNCP5_ModelBinding.Controllers
{
    public class OrderController : Controller
    {
        //When request is received at path "/order"
        [Route("/Order")]

        //bind only the desired properties of Order class, i.e. 'OrderDate', "InvoicePrice" and "Products"
        public IActionResult Index([Bind(nameof(Order.order_date), nameof(Order.invoice_price), nameof(Order.products))] Order order)
        {
            //if there are any validation errors (as per data annotations)
            if (!ModelState.IsValid)
            {
                string messages = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                //semd HTTP 400 response with error messages
                return BadRequest(messages);
            }

            return Content("Successful!");
        }
    }
}
