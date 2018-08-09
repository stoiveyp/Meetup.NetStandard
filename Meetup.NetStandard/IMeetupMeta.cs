using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Meta;

namespace Meetup.NetStandard
{
    public interface IMeetupMeta
    {
        Task<MeetupResponse<Status>> Status();
    }
}
