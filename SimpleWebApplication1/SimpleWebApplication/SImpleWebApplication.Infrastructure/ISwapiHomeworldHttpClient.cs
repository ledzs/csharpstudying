using System.Threading.Tasks;

namespace SImpleWebApplication.Infrastructure
{
    public interface ISwapiHomeworldHttpClient
    {
        Task<HomeworlInfoResponse> GetPlanetInfo(string personHomeworld);
    }
}