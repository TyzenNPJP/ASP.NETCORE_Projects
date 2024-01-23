// Home controller - Single Action method

using Microsoft.AspNetCore.Mvc;
using DNCP8_PartialViews.Models;

namespace DNCP8_PartialViews.Controllers
{
    public class HomeController : Controller
    {
        // Hard code data
        Weather w1 = new Weather()
        { city_code = 100, name = "Japan", date_time = new DateTime(2024, 01, 21, 16, 30, 0), temperature = 21 };

        Weather w2 = new Weather()
        { city_code = 101, name = "Sydney", date_time = new DateTime(2024, 01, 21, 18, 30, 0), temperature = 31 };

        Weather w3 = new Weather()
        { city_code = 102, name = "London", date_time = new DateTime(2024, 01, 21, 7, 30, 0), temperature = 8 };

        // Default route
        [Route("/")]
        //Action Method
        public IActionResult Index()
        {
            // Implementation of wrapper model class
            AllWeather AllWeather_obj = new AllWeather();
            AllWeather_obj.list_weather = new List<Weather> { w1, w2, w3 };
            // Return View page and send data from controller to view page
            return View(AllWeather_obj);
        }

        [Route("/cities")]
        public IActionResult Cities()
        {
            // Implementation of wrapper model class
            AllWeather AllWeather_obj = new AllWeather();
            AllWeather_obj.list_weather = new List<Weather> { w1, w2, w3 };
            return View(AllWeather_obj);
        }

        [Route("/about")]
        public IActionResult About()
        {
            return View();
        }
    }
}
