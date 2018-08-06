using System.Threading.Tasks;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public interface IMeetupMeta
    {
        Task<StatusResponse> Status(MeetupRequestOptions options = null);
    }
}
