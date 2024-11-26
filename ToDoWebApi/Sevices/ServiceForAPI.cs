using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System.Text.Json.Serialization;
using ToDoWebApi.Models;
using System;
using Newtonsoft.Json;


namespace ToDoWebApi.Sevices
{
    public class ServiceForAPI
    {
        private readonly HttpClient _httpClient;
        private const string APIkey = "YourAPIkey";
        private const string BaseUrl = "YourBaseUrlForRequest";

        public ServiceForAPI(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherApi> GetWeatherApi (string city)
        {
            var url = $"{BaseUrl}?q={city}&appid={APIkey}&units=metric";
            var responce = await _httpClient.GetAsync (url);

            if (!responce.IsSuccessStatusCode)
                throw new Exception("Request error!");

            string json = await responce.Content.ReadAsStringAsync();
            var weatherData = JsonConvert.DeserializeObject<dynamic> (json);

            return new WeatherApi
            {
                City = weatherData.name,
                Temperature = weatherData.main.temp
            };
        }



    }
}
