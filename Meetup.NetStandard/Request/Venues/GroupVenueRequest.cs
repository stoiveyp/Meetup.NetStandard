using System;
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
    }
}
