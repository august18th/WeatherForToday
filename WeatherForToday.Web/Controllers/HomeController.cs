using System;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using WeatherForToday.Models.Models;
using WeatherForToday.Services.Interfaces;

namespace WeatherForToday.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherService _weatherService;

        public HomeController(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<ActionResult> Index()
        {
            string userIp = HttpContext.Request.UserHostAddress;
            try
            {
                WeatherInfo weatherInfo = await _weatherService.GetWeatherForecastCelsius(userIp);
                return View(weatherInfo);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }
        }
    }
}