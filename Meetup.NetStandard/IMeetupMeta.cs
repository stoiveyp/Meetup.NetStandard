using System.Threading.Tasks;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public interface IMeetupMeta
    {
        Task<MeetupResponse<StatusResponse>> Status(MeetupRequestOptions options = null);
    }
}
