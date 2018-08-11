using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request;
using Meetup.NetStandard.Request.Venues;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Venues;

namespace Meetup.NetStandard
{
    public class VenueCalls : IMeetupVenues
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
                throw new ArgumentNullException(nameof(text), "Text must be specified for a find venue call");
            }

            return Find(new FindVenuesRequest(text));
        }

        public Task<MeetupResponse<Venue[]>> Find(string text, VenueOrderBy orderBy, bool descending = false)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text), "Text must be specified for a find venue call");
            }

            return Find(new FindVenuesRequest(text) { OrderBy = orderBy, Descending = descending });
        }

        public Task<MeetupResponse<Venue[]>> Find(FindVenuesRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            if (!string.IsNullOrWhiteSpace(request.Country) && request.Country.Length != 2)
            {
                throw new ArgumentOutOfRangeException("Country", "Country must be a 2 character code");
            }

            return MeetupRequestMethods.GetWithRequestAsync<Venue[]>("/find/venues", _options, request);
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

        private Task<MeetupResponse<Venue[]>> Recommended(MeetupRequest request)
        {
            return MeetupRequestMethods.GetWithRequestAsync<Venue[]>("/recommended/venues", _options, request);
        }

        public Task<MeetupResponse<Venue[]>> For(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            return For(new GroupVenueRequest(groupName));
        }

        public Task<MeetupResponse<Venue[]>> For(GroupVenueRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            return MeetupRequestMethods.GetWithRequestAsync<Venue[]>($"/{request.GroupName}/venues", _options, request);
        }

        public Task<MeetupResponse<Venue>> CreateFor(string groupName, Venue venue)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            if (venue == null)
            {
                throw new ArgumentNullException(nameof(venue));
            }

            return MeetupRequestMethods.PostWithContentAsync<Venue, Venue>($"/{groupName}/venues?fields=taglist", _options, venue);
        }
    }
}
