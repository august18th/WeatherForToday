using System;
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

        public ActionResult Index()
        {
            try
            {
                WeatherInfo weatherInfo = _weatherService.GetWeatherForecastCelsius("Kharkiv");
                return View(weatherInfo);
            }
            catch (Exception e)
            {
                return Content(e.Message);
            }        
        }
    }
}