using System;
using System.Collections.Generic;

namespace Meetup.NetStandard.Request.Venues
{
    public class GroupVenueRequest:PagedMeetupRequest
    {
        public GroupVenueRequest(string groupName)
        {
            if(string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }
            GroupName = groupName;
        }

        public string GroupName { get; }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string,string>{
                {"fields","taglist"}
            };

            AddPagination(dictionary);

            return dictionary;
        }
    }
}
