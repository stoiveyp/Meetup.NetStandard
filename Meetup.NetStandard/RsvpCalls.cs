using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Events;
using Meetup.NetStandard.Request.Rsvps;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Events;
using Meetup.NetStandard.Response.Rsvps;

namespace Meetup.NetStandard
{
    public class RsvpCalls:IMeetupRsvps
    {
        private readonly MeetupClientOptions _options;

        public RsvpCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public Task<MeetupResponse<Rsvp[]>> For(string groupName, string eventId)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            if (string.IsNullOrWhiteSpace(eventId))
            {
                throw new ArgumentNullException(nameof(eventId));
            }

            return For(new GetRsvpsRequest(groupName, eventId));
        }

        public Task<MeetupResponse<Rsvp[]>> For(GetRsvpsRequest request)
        {
            return MeetupRequestMethods.GetWithRequestAsync<Rsvp[]>($"{request.GroupName}/events/{request.EventId}/rsvps", _options, request);
        }
    }
}
