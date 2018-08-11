using System;
using System.Collections.Generic;
using System.Linq;

namespace Meetup.NetStandard.Request.Venues
{
    public class RecommendedVenuesRequest:PagedMeetupRequest
    {
        public IEnumerable<string> Categories { get; set; }
        public string Country { get; set; }
        public IEnumerable<string> GroupNames { get; set; }
        public double? Latitude { get; set; }
        public IEnumerable<string> GroupIds { get; set; }
        public double? Longitude { get; set; }
        public string Location { get; set; }
        public int? MinimumGroups { get; set; }
        public double? MilesRadius { get; set; }
        public MeetupTimeSpan UsedBetween { get; set; }
        public string Zip { get; set; }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                { "fields", "taglist" }
            };

            var catArray = Categories?.ToArray();
            if((catArray?.Length ?? 0) > 0)
            {
                dictionary.Add("category", string.Join(",", catArray));
            }

            if (!string.IsNullOrWhiteSpace(Country))
            {
                dictionary.Add("country", Country);
            }

            var groupIdArray = GroupIds?.ToArray();
            if ((groupIdArray?.Length ?? 0) > 0)
            {
                dictionary.Add("group_id", string.Join(",", groupIdArray));
            }

            var groupNameArray = GroupNames?.ToArray();
            if ((groupNameArray?.Length ?? 0) > 0)
            {
                dictionary.Add("group_urlname", string.Join(",", groupNameArray));
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

            if(MinimumGroups.HasValue)
            {
                dictionary.Add("min_groups", MinimumGroups.Value.ToString());
            }

            if (MilesRadius.HasValue)
            {
                dictionary.Add("radius", MilesRadius.ToString());
            }

            if(UsedBetween != null)
            {
                dictionary.Add("used_between", UsedBetween.ToUrl);
            }

            if (!string.IsNullOrWhiteSpace(Zip))
            {
                dictionary.Add("zip", Zip);
            }

            AddPagination(dictionary);

            return dictionary;
        }
    }
}
