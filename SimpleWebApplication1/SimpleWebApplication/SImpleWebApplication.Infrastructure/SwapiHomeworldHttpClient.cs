using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SImpleWebApplication.Infrastructure
{
    public class SwapiHomeworldHttpClient : ISwapiHomeworldHttpClient
    {
        private readonly HttpClient _httpClient;

        public SwapiHomeworldHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<HomeworlInfoResponse> GetPlanetInfo(string personHomeworld)
        {
            var response = await _httpClient.GetAsync(personHomeworld); 
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<HomeworlInfoResponse>(responseBody, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                });
                return deserializedObject;
            }

            return null;
        }

        public async Task<HomeworlInfoResponse> GetPlanetInfo(int planetId)
        {
            var response = await _httpClient.GetAsync(planetId.ToString());
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<HomeworlInfoResponse>(responseBody, new JsonSerializerSettings //<> generic тип
                {
                    ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new SnakeCaseNamingStrategy()
                    }
                });
                return deserializedObject;
            }

            return null;
        }
    }

    public class HomeworlInfoResponse
    {
        public string Name { get; set; }
        public string RotationPeriod { get; set; }
        public string OrbitalPeriod { get; set; }

        public string[] Residents { get; set; }//!!получаем массив строк, свойство
    }
}