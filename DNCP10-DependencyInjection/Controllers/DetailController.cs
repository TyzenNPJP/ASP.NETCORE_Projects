// Weather Detail page - Single action method

using DNCP10_Services;
using DNCP10_ServiceContracts;
using Microsoft.AspNetCore.Mvc;

namespace DNCP9_ViewComponents.Controllers
{
    public class DetailController : Controller
    {
        // Route with route parameter and contraint
        [Route("/weather/{city_code:int}")]
        // Action method that accepts route arguments sent via view and stores it in a variable
        public IActionResult Index([FromRoute] string city_code)
        {
            int city_code2 = Convert.ToInt32(city_code);

            // Linq queries the list of objects and selects the one with a given city code
            Weather? w = allWeather_obj.list_weathers.Where(x => x.city_code == city_code2).FirstOrDefault();

            // Returns view page and sends a data to it
            return View(w);
        }
    }
}
