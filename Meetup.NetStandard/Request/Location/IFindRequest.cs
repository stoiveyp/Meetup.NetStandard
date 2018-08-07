using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Location
{
    public interface IFindRequest : IFindRequestPager<IFindRequest>
    {
        IFindNameRequest ByName(string name);
        IFindCoordinateRequest ByCoordinate(double longitude, double latitude);

    }
}
