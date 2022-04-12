using System.Collections.Generic;
using System.Threading.Tasks;
using SImpleWebApplication.Infrastructure;

namespace SimpleWebApplication.ApplicationServices
{
    public class SwapiApplicationService //сервис с бизнес-логикой
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
        public async Task<object> GetPlanetInfoByPeople(int planetId)
        {
            var planet = await _swapiHomeworldHttpClient.GetPlanetInfo(planetId);

            var peopleOnPlanet = new List<string>();
            foreach (var item in planet.Residents)
            {
                var people = await _swapiPeopleHttpClient.GetPeopleInfo(item);
                peopleOnPlanet.Add(people.Name.ToString());
            }
            return new
            {
                Name = planet,
                Residents = peopleOnPlanet
            };
        }
    }
}