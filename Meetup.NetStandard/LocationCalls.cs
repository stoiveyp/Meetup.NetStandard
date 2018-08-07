using System;
using System.Collections.Generic;
using System.Text;
using Meetup.NetStandard.Request.Location;

namespace Meetup.NetStandard
{
    internal class LocationCalls:IMeetupLocation
    {
        private readonly DefaultClientOptions _options;
        internal LocationCalls(DefaultClientOptions options)
        {
            _options = options;
        }

        public IFindRequest Find()
        {
           return new FindRequest(_options);
        }
    }
}
