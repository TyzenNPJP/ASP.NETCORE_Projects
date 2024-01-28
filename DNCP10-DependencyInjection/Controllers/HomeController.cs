// Home Controller

using Microsoft.AspNetCore.Mvc;
using DNCP10_ServiceContracts;

namespace DNCP10_DependencyInjection.Controllers
{
    public class HomeController : Controller
    {
        // Create a reference object
        public IAllWeather IAllWeatherObj;

        public HomeController(IAllWeather newObj)
        {
            IAllWeatherObj = newObj;
        }

        [Route("/")]
        public IActionResult Index()
        {
            AllWeather allWeatherObj = new AllWeather();
            ViewBag.allWeathersObj = allWeatherObj;
            return View(allWeatherObj);
        }
    }
}
