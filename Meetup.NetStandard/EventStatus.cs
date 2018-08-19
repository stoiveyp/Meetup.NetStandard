using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard
{
    [Flags]
    public enum EventStatus
    {
        Cancelled = 1,
        Draft = 2,
        Past = 4,
        Proposed = 8,
        Suggested = 16,
        Upcoming = 32
    }
}
