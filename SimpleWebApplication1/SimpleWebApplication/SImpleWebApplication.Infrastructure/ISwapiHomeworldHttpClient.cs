using System.Threading.Tasks;

namespace SImpleWebApplication.Infrastructure
{
    public interface ISwapiHomeworldHttpClient
    {
        Task<HomeworlInfoResponse> GetPlanetInfo(string personHomeworld);
        Task<HomeworlInfoResponse> GetPlanetInfo(int planetId);
        
    }
}