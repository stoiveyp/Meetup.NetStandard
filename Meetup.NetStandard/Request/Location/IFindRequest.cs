using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Location
{
    public interface IFindRequest : IFindRequestPager<IFindRequest>,IFindExecutor
    {
        IFindRequestAdditional ByName(string name);
        IFindRequestAdditional ByCoordinate(double longitude, double latitude);
    }
}
