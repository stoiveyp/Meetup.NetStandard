using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Location
{
    public interface IFindRequestAdditional:IFindRequestPager<IFindRequestAdditional>,IFindExecutor
    {
        IFindRequestAdditional AndByName(string name);
        IFindRequestAdditional AndByCoordinate(double longitude, double latitude);
    }
}
