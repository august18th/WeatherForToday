using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WeatherForToday.Models.Models;
using WeatherForToday.Services.Interfaces;

namespace WeatherForToday.Services.Services
{
    public class WeatherService : IWeatherService
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;

        public WeatherService()
        {
            _baseUrl = "http://api.openweathermap.org/data/2.5/weather?q=";
            _apiKey = "97c09f52033f4b858e7007429f0441af";
        }

        private async Task<LocationInfo> GetUserLocationInfoAsync(string userIp)
        {
            const string localHostIp = "::1";
            if (userIp == localHostIp)
                userIp = String.Empty;
            var baseAddress = new Uri("https://api.ipdata.co/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                httpClient.DefaultRequestHeaders.TryAddWithoutValidation("accept", "application/json");

                using (var response = await httpClient.GetAsync(userIp))
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<LocationInfo>(responseData);
                }
            }
        }

        public async Task<WeatherInfo> GetWeatherForecastCelsius(string userIp)
        {
            using (var client = new WebClient())
            {
                string response;
                try
                {
                    LocationInfo userLocation = await GetUserLocationInfoAsync(userIp);
                    response = client.DownloadString(_baseUrl + userLocation.City
                                                          + "&units=metric&appid=" + _apiKey);
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