using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Venues;

namespace Meetup.NetStandard
{
    public class VenueCalls:IMeetupVenues
    {
        private readonly MeetupClientOptions _options;

        public VenueCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public Task<MeetupResponse<Venue[]>> Find(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text),"Text must be specified for a find venue call");
            }

            return Find(new FindVenuesRequest { Text = text });
        }

        public async Task<MeetupResponse<Venue[]>> Find(FindVenuesRequest request)
        {
            if(string.IsNullOrWhiteSpace(request.Text))
            {
                throw new InvalidOperationException("Text must be specified for a find venue call");
            }
            var response = await MeetupRequestMethods.GetAsync("/find/venues", _options, request);
            return await response.AsObject<Venue[]>(_options);
        }
    }
}
