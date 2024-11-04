using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace F1_App.Services
{
    public class DataFetcher
    {
        private readonly HttpClient _httpClient;

        public DataFetcher()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Driver>> FetchDriversAsync(string apiUrl)
        {
            var response = await _httpClient.GetStringAsync(apiUrl);
            var drivers = JsonConvert.DeserializeObject<List<Driver>>(response);
            return drivers;
        }
    }
}
