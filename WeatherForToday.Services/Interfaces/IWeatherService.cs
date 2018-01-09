using WeatherForToday.Models.Models;

namespace WeatherForToday.Services.Interfaces
{
    public interface IWeatherService
    {
        WeatherInfo GetWeatherForecastCelsius(string city);
    }
}