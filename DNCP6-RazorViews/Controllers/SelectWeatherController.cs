using DNCP6_RazorViews.Controllers;
using DNCP6_RazorViews.Models;
using Microsoft.AspNetCore.Mvc;

namespace DNCP6_RazorViews.Controllers
{
    public class SelectWeatherController : Controller
    {
        CityWeather cw1 = new CityWeather
        {
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

        CityWeather cw3 = new CityWeather
        {
            City_Unique_Code = "PAR",
            City_Name = "Paris",
            Date_Time = Convert.ToDateTime("2030-01-01 9:00"),
            TemperatureF = 82
        };

        [HttpGet("/weather/{city_code}")]
        public IActionResult Index()
        {
            string? temp_code = Convert.ToString(Request.RouteValues["city_code"]);

            if (temp_code == null || temp_code.Length != 3)
            {
                return BadRequest("Bad City codes used.\nAvailable City code: 'LDN', 'NYC', 'PAR'");
            }
            else if (temp_code == "LDN")
            {
                StatusCode(200);
                return View(cw1);
            }
            else if (temp_code == "NYC")
            {
                StatusCode(200);
                return View(cw2);
            }
            else if (temp_code == "PAR")
            {
                StatusCode(200);
                return View(cw3);
            }
            else
            {
                return BadRequest("Bad City codes used.\nAvailable City code: 'LDN', 'NYC', 'PAR'");
            }
        }
    }
}
