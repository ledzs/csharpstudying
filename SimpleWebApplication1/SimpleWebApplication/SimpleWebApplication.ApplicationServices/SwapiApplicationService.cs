using System.Threading.Tasks;
using SImpleWebApplication.Infrastructure;

namespace SimpleWebApplication.ApplicationServices
{
    public class SwapiApplicationService
    {
        private readonly ISwapiPeopleHttpClient _swapiPeopleHttpClient;
        private readonly ISwapiHomeworldHttpClient _swapiHomeworldHttpClient;

        public SwapiApplicationService(ISwapiPeopleHttpClient swapiPeopleHttpClient, ISwapiHomeworldHttpClient swapiHomeworldHttpClient)
        {
            _swapiPeopleHttpClient = swapiPeopleHttpClient;
            _swapiHomeworldHttpClient = swapiHomeworldHttpClient;
        }

        public async Task<object> GetPersonInfoWithHomeworld(int peopleId)
        {
            var person = await _swapiPeopleHttpClient.GetPeopleInfo(peopleId);
            var planetInfo = await _swapiHomeworldHttpClient.GetPlanetInfo(person.Homeworld);

            return new
            {
                Name = person.Name,
                PlanetName = planetInfo.Name
            };
        }
    }
}