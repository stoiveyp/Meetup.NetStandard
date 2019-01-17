using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Rsvps
{
    public class GetRsvpsRequest:MeetupRequest
    {
        public string GroupName { get; set; }
        public string EventId { get; set; }
        public RsvpStatus? Response { get; set; }
        public RsvpOrderBy? OrderBy { get; set; }
        public bool? Descending { get; set; }

        public GetRsvpsRequest(string groupName, string eventId)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            if (string.IsNullOrWhiteSpace(eventId))
            {
                throw new ArgumentNullException(nameof(eventId));
            }

            GroupName = groupName;
            EventId = eventId;
        }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"photo-host","public" }
            };

            if (Response.HasValue)
            {
                switch (Response)
                {
                    case RsvpStatus.YesAndNo:
                        dictionary.Add("response", "yes,no");
                        break;
                    case RsvpStatus.YesOnly:
                        dictionary.Add("response", "yes");
                        break;
                    case RsvpStatus.NoOnly:
                        dictionary.Add("response", "no");
                        break;
                }
            }

            if (OrderBy.HasValue)
            {
                dictionary.Add("order", OrderBy.ToString().ToLowerInvariant());
            }

            if (Descending.HasValue)
            {
                dictionary.Add("desc", Descending.Value.ToString().ToLowerInvariant());
            }

            return dictionary;
        }
    }
}
