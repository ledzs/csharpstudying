using System.Threading.Tasks;

namespace SImpleWebApplication.Infrastructure
{
    public interface ISwapiPeopleHttpClient
    {
        Task<PeopleInfoServiceResponce> GetPeopleInfo(int peopleId);
    }
}