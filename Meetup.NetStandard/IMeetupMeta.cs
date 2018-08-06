using System.Threading.Tasks;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public interface IMeetupMeta
    {
        Task<MeetupResponse<Status>> Status(MeetupRequestOptions options = null);
    }
}
