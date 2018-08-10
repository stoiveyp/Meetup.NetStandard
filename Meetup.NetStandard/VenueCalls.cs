using System;
namespace Meetup.NetStandard
{
    public class VenueCalls:IMeetupVenues
    {
        private readonly MeetupClientOptions _options;

        public VenueCalls(MeetupClientOptions options)
        {
            _options = options;
        }


    }
}
