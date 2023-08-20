using DNCP6_RazorViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNCP6_RazorViews.Controllers
{
    public class HomeController : Controller
    {
        CityWeather cw1 = new CityWeather {
            City_Unique_Code = "LDN",
            City_Name = "London",
            Date_Time = Convert.ToDateTime("2030-01-01 8:00"),
            TemperatureF = 33
        };

        CityWeather cw2 = new CityWeather
        {
            City_Unique_Code = "NYC",
            City_Name = "New York",
            Date_Time = Convert.ToDateTime("2030-01-01 3:00"),
            TemperatureF = 60
        };

        CityWeather cw3 = new CityWeather {
            City_Unique_Code = "PAR",
            City_Name = "Paris",
            Date_Time = Convert.ToDateTime("2030-01-01 9:00"),
            TemperatureF = 82
        };

        [HttpGet("/")]
        public IActionResult Index()
        {
            /* Did not transfer object from one controller to another
            TempData["cw1_0"] = cw1;
            TempData["cw2_0"] = cw2;
            TempData["cw3_0"] = cw3;
            */

            CityWeatherWrapper cww = new CityWeatherWrapper { cww1 = cw1, cww2 = cw2 , cww3 = cw3};
            StatusCode(200);
            return View(cww);
        }
    }
}
