using Microsoft.AspNetCore.Mvc;
using SimpleWebApplication.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleWebApplication.Controllers
{
    [ApiController]
    [Route("planet-info")]
    public class PlanetInfoController : ControllerBase //:встроенный класс
    {
        private readonly SwapiApplicationService _applicationService;
        public PlanetInfoController(SwapiApplicationService applicationService)//конструктор контроллера
        {
            _applicationService = applicationService;
        }

        [HttpPost("{planetId}")] //всё в квадратных скобках называется "атрибуты"
        public async Task<object> GetPlanetInfo(int planetId)
        {
            var result = await _applicationService.GetPlanetInfoByPeople(planetId);
            return result;
        }
    }
}
