using System;
using System.Collections.Generic;
using System.Net.Http.Headers;

namespace Meetup.NetStandard.Request.Topics
{
    public class FindTopicCategoriesRequest:MeetupRequest
    {
        public double? Longitude { get; set; }
        public double? Latitude { get; set; }
        public double? MilesRadius { get; set; }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string,string>
            {
                {"photo-host","public"}
            };

            if (Latitude.HasValue)
            {
                dictionary.Add("lat", Latitude.Value.ToString());
            }

            if (Longitude.HasValue)
            {
                dictionary.Add("lon",Longitude.Value.ToString());
            }

            if (MilesRadius.HasValue)
            {
                dictionary.Add("radius",MilesRadius.Value.ToString());
            }


            return dictionary;
        }
    }
}
