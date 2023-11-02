using GalaxyQuest.Models;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;

namespace GalaxyQuest.Services
{
    public class MilkyWayGalaxy
    {
        static public List<Planet> Planets = new List<Planet>() {
            new Planet() { Name = "Mercury", Population = 1 },
            new Planet() { Name = "Venus", Population = 2 },
            new Planet() { Name = "Earth", Population = 7_888_000_000 },
            new Planet() { Name = "Mars", Population = 3 },
            new Planet() { Name = "Jupiter", Population = 1 },
            new Planet() { Name = "Saturn", Population = 1 },
            new Planet() { Name = "Uranus", Population = 0 },
            new Planet() { Name = "Neptune", Population = 0 }
        };

        private readonly HttpClient _httpClient;

        public MilkyWayGalaxy(IHttpClientFactory clientFactory)
        {
            _httpClient = clientFactory.CreateClient("SwapiApi");
        }

        //public async Task<List<Planet>> GetPlanets()
        //{
        //    string url = "";

        //    try
        //    {
        //        HttpResponseMessage response = await _httpClient.GetAsync(url);
        //        response.EnsureSuccessStatusCode();
        //        string responseBody = await response.Content.ReadAsStringAsync();

        //        var planets = Newtonsoft.Json.JsonConvert.DeserializeObject()
        //    }
        //}

        public async Task<List<Planet>> GetPlanets()
        {
            var url = string.Format("/planets");
            var result = new List<Planet>();
            var response = await _httpClient.GetAsync(url);

            //if (response.IsSuccessStatusCode)
            //{


                var stringResponse = await response.Content.ReadAsStringAsync();
            result = JsonSerializer.Deserialize<List<Planet>>(stringResponse,
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

            //}
            //else
            //{
            //    throw new HttpRequestException(response.ReasonPhrase);
            //}

            return result;
        }



    }
}
