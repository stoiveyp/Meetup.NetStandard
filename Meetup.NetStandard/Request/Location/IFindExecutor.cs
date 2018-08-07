using System.Threading.Tasks;

namespace Meetup.NetStandard.Request.Location
{
    public interface IFindExecutor : IFindRequestPager<IFindExecutor>
    {
        Task<FindResponse> Execute();
    }
}