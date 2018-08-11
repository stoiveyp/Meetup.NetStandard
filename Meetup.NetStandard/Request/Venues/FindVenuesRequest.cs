using System;
using System.Collections.Generic;

namespace Meetup.NetStandard.Request.Venues
{
    public class FindVenuesRequest : PagedMeetupRequest
    {
        public FindVenuesRequest(string text)
        {
            if(string.IsNullOrWhiteSpace(text))
            {
                throw new ArgumentNullException(nameof(text));
            }

            Text = text;
        }

        public string Text { get; set; }
        public string Country { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Location { get; set; }
        public double? MilesRadius { get; set; }
        public string Zip { get; set; }
        public VenueOrderBy? OrderBy { get; set; }
        public bool Descending { get; set; }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "text", Text },
                { "fields", "taglist" }
            };

            if (!string.IsNullOrWhiteSpace(Country))
            {
                dictionary.Add("country", Country);
            }

            if (Latitude.HasValue)
            {
                dictionary.Add("lat", Latitude.ToString());
            }

            if (Longitude.HasValue)
            {
                dictionary.Add("lon", Longitude.ToString());
            }

            if (!string.IsNullOrWhiteSpace(Location))
            {
                dictionary.Add("location", Location);
            }

            if (MilesRadius.HasValue)
            {
                dictionary.Add("radius", MilesRadius.ToString());
            }

            if (!string.IsNullOrWhiteSpace(Zip))
            {
                dictionary.Add("zip", Zip);
            }

            if(OrderBy.HasValue)
            {
                dictionary.Add("order", OrderBy.ToString().ToLowerInvariant());
            }

            if(Descending)
            {
                dictionary.Add("desc", "true");
            }

            AddPagination(dictionary);

            return dictionary;
        }
    }
}
