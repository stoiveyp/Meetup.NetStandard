using System;
using System.Collections.Generic;

namespace Meetup.NetStandard.Request
{
    public class FindVenuesRequest : MeetupRequest
    {
        public string Text { get; internal set; }
        public string Country { get; internal set; }
        public double? Latitude { get; internal set; }
        public double? Longitude { get; internal set; }
        public string Location { get; internal set; }
        public double? MilesRadius { get; internal set; }
        public string Zip { get; internal set; }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>();
            dictionary.Add("text", Text);
            dictionary.Add("fields", "taglist");

            if(!string.IsNullOrWhiteSpace(Country))
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

            return dictionary;
        }
    }
}
