using System;
using System.Collections.Generic;
using System.Linq;
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
        public bool? Descending { get; set; }

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

            var stateString = GetStates(Status);
            if (!string.IsNullOrWhiteSpace(stateString))
            {
                dictionary.Add("status",stateString.ToLower());
            }

            if (Descending.HasValue)
            {
                dictionary.Add("desc",Descending.Value.ToString().ToLowerInvariant());
            }


            return dictionary;
        }

        private string GetStates(EventStatus? status)
        {
            if (!status.HasValue)
            {
                return string.Empty;
            }

            var osb = new StringBuilder();
            foreach(var value in Enum.GetValues(typeof(EventStatus)).Cast<EventStatus>())
            {
                if ((status.Value & value) == value)
                {
                    if (osb.Length > 0)
                    {
                        osb.Append(",");
                    }
                    osb.Append(value.ToString().ToLowerInvariant());
                }
            }

            return osb.ToString();
        }
    }
}
