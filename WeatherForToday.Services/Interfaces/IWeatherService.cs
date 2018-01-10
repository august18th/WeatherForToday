using System.Threading.Tasks;
using WeatherForToday.Models.Models;

namespace WeatherForToday.Services.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherInfo> GetWeatherForecastCelsius(string userIp);
    }
}