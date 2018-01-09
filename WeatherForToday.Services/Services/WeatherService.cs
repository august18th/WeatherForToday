using System;
using System.Net;
using Newtonsoft.Json;
using WeatherForToday.Models.Models;
using WeatherForToday.Services.Interfaces;

namespace WeatherForToday.Services.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string _url;
        private readonly string _apiKey;

        public WeatherService()
        {
            _url = "http://api.openweathermap.org/data/2.5/weather?q=";
            _apiKey = "97c09f52033f4b858e7007429f0441af";
        }

        public WeatherInfo GetWeatherForecastCelsius(string city)
        {
            using (var client = new WebClient())
            {
                string response;
                try
                {
                    response = client.DownloadString(_url + city + "&units=metric&appid=" + _apiKey);
                }
                catch (Exception)
                {
                    throw new Exception();
                }

                return !string.IsNullOrEmpty(response)
                    ? JsonConvert.DeserializeObject<WeatherInfo>(response)
                    : throw new NullReferenceException();
            }
        }
    }
}