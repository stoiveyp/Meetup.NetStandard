using System.Collections.Generic;
using System.Globalization;

namespace Meetup.NetStandard.Request.Geo
{
    public class FindLocationRequest:MeetupRequest
    {
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string Name { get; set; }
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string,string>();
            if (!string.IsNullOrWhiteSpace(Name))
            {
                dictionary.Add("query",Name);
            }

            if (Longitude.HasValue)
            {
                dictionary.Add("lon", Longitude.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (Latitude.HasValue)
            {
                dictionary.Add("lat", Latitude.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (PageSize.HasValue)
            {
                dictionary.Add("page", PageSize.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (Page.HasValue)
            {
                dictionary.Add("offset", Page.Value.ToString(CultureInfo.InvariantCulture));
            }

            return dictionary;
        }
    }
}
