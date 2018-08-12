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

            return For(new GetEventsRequest(groupName));
        }

        public Task<MeetupResponse<Event[]>> For(GetEventsRequest request)
        {
            return MeetupRequestMethods.GetWithRequestAsync<Event[]>($"{request.GroupName}/events", _options, request);
        }
    }
}
