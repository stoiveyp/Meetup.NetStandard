using System;
using System.Collections.Generic;
using System.Globalization;

namespace Meetup.NetStandard.Request
{
    public abstract class PagedMeetupRequest:MeetupRequest
    {
        public int? Page { get; set; }
        public int? PageSize { get; set; }

        protected void AddPagination(Dictionary<string, string> dictionary)
        {
            if (PageSize.HasValue)
            {
                dictionary.Add("page", PageSize.Value.ToString(CultureInfo.InvariantCulture));
            }

            if (Page.HasValue)
            {
                dictionary.Add("offset", Page.Value.ToString(CultureInfo.InvariantCulture));
            }
        }
    }
}
