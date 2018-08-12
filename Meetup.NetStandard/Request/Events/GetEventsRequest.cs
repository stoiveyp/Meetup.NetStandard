using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Events
{
    public class GetEventsRequest:MeetupRequest
    {
        public string GroupName { get; set; }
        public DateTime? NoLaterThan { get; set; }
        public DateTime? NoEarlierThan { get; set; }
        public int? PageSize { get; set; }
        public EventScrollTo? ScrollTo { get; set; }
        public EventStatus? Status { get; set; }

        public GetEventsRequest(string groupName)
        {
            if (string.IsNullOrWhiteSpace(groupName))
            {
                throw new ArgumentNullException(nameof(groupName));
            }

            GroupName = groupName;
        }

        public override Dictionary<string, string> AsDictionary()
        {
            var dictionary = new Dictionary<string, string>
            {
                {"photo-host","public" }
            };

            if (NoEarlierThan.HasValue)
            {
                dictionary.Add("no_earlier_than",NoEarlierThan.Value.ToString("s"));
            }

            if (NoLaterThan.HasValue)
            {
                dictionary.Add("no_later_than",NoLaterThan.Value.ToString("s"));
            }

            if (PageSize.HasValue)
            {
                dictionary.Add("page",PageSize.Value.ToString());
            }

            if (ScrollTo.HasValue)
            {
                dictionary.Add("scroll",ScrollTo.Value.ToString());
            }

            if (Status.HasValue)
            {
                dictionary.Add("status",Status.Value.ToString().ToLower());
            }

            return dictionary;
        }
    }
}
