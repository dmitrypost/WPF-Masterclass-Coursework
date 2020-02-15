using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Weather.Enums;
using Weather.Interfaces;
using Weather.Models;

namespace Weather.Services
{
    public class AccuWeatherService : IAccuWeatherService, IDisposable
    {
        private readonly ILogger _logger = LogManager.GetCurrentClassLogger();
        private readonly HttpClient _client;
        private readonly string _apiKey;

        public AccuWeatherService(ISettingRepository settingRepository)
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("http://dataservice.accuweather.com/")
            };

            _apiKey = settingRepository.GetValue(SettingKey.AccuWeatherApiKey);
            if (string.IsNullOrWhiteSpace(_apiKey)) throw new Exception($"AccuWeather API Key is empty");
        }

        public void Dispose() => _client?.Dispose();


        public async Task<IList<City>> GetCitiesAutoComplete(string query)
        {
            try
            {
                var endpoint = $"locations/v1/cities/autocomplete?apikey={_apiKey}&q={query}";
                var response = await _client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode) return new List<City>();

                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<City>>(jsonString);
            }
            catch (Exception ex)
            {
                _logger.Error(ex,$"Error getting autocomplete city list; query: {query}");
                throw;
            }
        }

        public async Task<CurrentConditions> GetCurrentConditions(string locationKey)
        {
            try
            {
                var endpoint = $"currentconditions/v1/{locationKey}?apikey={_apiKey}";
                var response = await _client.GetAsync(endpoint);

                if (!response.IsSuccessStatusCode) return new CurrentConditions();

                var jsonString = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CurrentConditions>>(jsonString).FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.Error(ex,$"Error getting current conditions; location key: {locationKey}");
                throw;
            }
        }
    }
}
