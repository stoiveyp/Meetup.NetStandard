using System.Threading.Tasks;
using Meetup.NetStandard.Response.Location;

namespace Meetup.NetStandard.Request.Location
{
    public interface IFindExecutor
    {
        Task<FindResponse> Execute();
    }
}