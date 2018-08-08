using System.Threading.Tasks;

namespace Meetup.NetStandard.Response
{
    public class MeetupLink<T>
    {
        public string Url { get; private set; }

        public Task<MeetupResponse<T>> Execute(MeetupClient client)
        {
            return client.GoToLink(this);
        }
    }
}