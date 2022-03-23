using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace SImpleWebApplication.Infrastructure
{
    public class SwapiPeopleHttpClient  : ISwapiPeopleHttpClient
    {
        private readonly HttpClient _httpClient;

        public SwapiPeopleHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        
        public async Task<PeopleInfoServiceResponce> GetPeopleInfo(int peopleId)
        {
            return await GetResponseAsync(peopleId.ToString());
        }

        
        public async Task<PeopleInfoServiceResponce> GetPeopleInfo(string url)
        {
            return await GetResponseAsync(url);
        }

        private async Task<PeopleInfoServiceResponce> GetResponseAsync(string url)
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var deserializedObject = JsonConvert.DeserializeObject<PeopleInfoServiceResponce>(responseBody,
                    new JsonSerializerSettings
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

    public class PeopleInfoServiceResponce
    {
        public string Name { get; set; }
        public string Height { get; set; }
        public string Mass { get; set; }
        public string BirthYear { get; set; }
        public string Gender { get; set; }
        public string Homeworld { get; set; }
        //public LocationResponse Homeworld { get; set; }

        /*public class LocationResponse
        {
            public string Name { get; set; }
            public string Population { get; set; }
        }*/
    }
}