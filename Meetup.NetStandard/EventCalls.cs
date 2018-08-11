using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Events;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Events;

namespace Meetup.NetStandard
{
    public class EventCalls:IMeetupEvents
    {
        private readonly MeetupClientOptions _options;

        public EventCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public Task<MeetupResponse<Event[]>> For(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            throw new NotImplementedException();
        }

        public Task<MeetupResponse<Event[]>> For(GetEventsRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
