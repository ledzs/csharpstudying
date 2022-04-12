using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleWebApplication.ApplicationServices;
using SImpleWebApplication.Infrastructure;

namespace SimpleWebApplication.Controllers
{
    [ApiController]
    [Route("people-info")]
    public class PeopleInfoController : ControllerBase
    {
        private readonly SwapiApplicationService _applicationService;//_ т.к. поле - приватное

        public PeopleInfoController(SwapiApplicationService applicationService)//конструктор контроллера
        {
            _applicationService = applicationService;
        }
        
        [HttpPost("{peopleId}")] //всё в квадратных скобках называется "атрибуты"
        public async Task<object> GetPeopleInfo(int peopleId)
        {
            var result = await _applicationService.GetPersonInfoWithHomeworld(peopleId);
            return result;
        }
    }
}