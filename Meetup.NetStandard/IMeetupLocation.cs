using System;
using System.Collections.Generic;
using System.Text;
using Meetup.NetStandard.Request.Location;

namespace Meetup.NetStandard
{
    public interface IMeetupLocation
    {
        IFindRequest Find();
    }
}
