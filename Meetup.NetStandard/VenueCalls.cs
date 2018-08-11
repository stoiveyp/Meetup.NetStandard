using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Request.Venues;
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

            return Find(new FindVenuesRequest(text));
        }

        public Task<MeetupResponse<Venue[]>> Find(string text, VenueOrderBy orderBy, bool descending = false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Text must be specified for a find venue call");
            }

            return Find(new FindVenuesRequest(text){OrderBy=orderBy,Descending=descending });
        }

        public async Task<MeetupResponse<Venue[]>> Find(FindVenuesRequest request)
        {
            if(request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if(!string.IsNullOrWhiteSpace(request.Country) && request.Country.Length != 2)
            {
                throw new ArgumentOutOfRangeException("Country","Country must be a 2 character code");
            }

            var response = await MeetupRequestMethods.GetAsync("/find/venues", _options, request);
            return await response.AsObject<Venue[]>(_options);
        }

        public Task<MeetupResponse<Venue[]>> Recommended()
        {
            return Recommended(MeetupRequest.FieldsOnly("taglist"));
        }

        public Task<MeetupResponse<Venue[]>> Recommended(RecommendedVenuesRequest request)
        {
            if (!string.IsNullOrWhiteSpace(request?.Country) && request.Country.Length != 2)
            {
                throw new ArgumentOutOfRangeException("Country", "Country must be a 2 character code");
            }

            return Recommended(request ?? MeetupRequest.FieldsOnly("taglist"));
        }

        private async Task<MeetupResponse<Venue[]>> Recommended(MeetupRequest request)
        {
            var response = await MeetupRequestMethods.GetAsync("/recommended/venues", _options, request);
            return await response.AsObject<Venue[]>(_options);
        }
    }
}
