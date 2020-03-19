using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaTracker.Models;
using Newtonsoft.Json;

namespace CoronaTracker.Services
{
    public class CountriesService
    {
        private readonly HttpClient client;

        public CountriesService()
        {
            client = new HttpClient();
        }

        public async Task<IEnumerable<CountryModel>> LoadAsync()
        {
            var uri = new Uri("https://corona.lmao.ninja/countries");
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var serializerSettings = new JsonSerializerSettings();
                serializerSettings.NullValueHandling = NullValueHandling.Ignore;
                return JsonConvert.DeserializeObject<List<CountryModel>>(content, serializerSettings);
            }

            throw new HttpRequestException("Failed to retrieve countries data from server.");
        }
    }
}
