// Weather Detail page - Single action method

using DNCP6_RazorViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNCP6_RazorViews.Controllers
{
    public class DetailController : Controller
    {
        // Route with route parameter and contraint
        [Route("/weather/{city_code:int}")]
        // Action method that accepts route arguments sent via view and stores it in a variable
        public IActionResult Index([FromRoute] string city_code)
        {
            // Hard code data
            Weather w1 = new Weather()
            { city_code = 100, name = "Japan", date_time = new DateTime(2024, 01, 21, 16, 30, 0), temperature = 21 };

            Weather w2 = new Weather()
            { city_code = 101, name = "Sydney", date_time = new DateTime(2024, 01, 21, 18, 30, 0), temperature = 31 };

            Weather w3 = new Weather()
            { city_code = 102, name = "London", date_time = new DateTime(2024, 01, 21, 7, 30, 0), temperature = 8 };

            AllWeather AllWeather_obj = new AllWeather();
            AllWeather_obj.list_weather = new List<Weather> { w1, w2, w3 };

            int city_code2 = Convert.ToInt32(city_code);

            // Linq queries the list of objects and selects the one with a given city code
            Weather? w = AllWeather_obj.list_weather.Where(x => x.city_code == city_code2).FirstOrDefault();

            // Returns view page and sends a data to it
            return View(w);
        }
    }
}
