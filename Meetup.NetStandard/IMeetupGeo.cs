using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Geo;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Geo;

namespace Meetup.NetStandard
{
    public interface IMeetupGeo
    {
        Task<MeetupResponse<Location[]>> FindLocation(string name);
        Task<MeetupResponse<Location[]>> FindLocation(double longitude, double latitude);
        Task<MeetupResponse<Location[]>> FindLocation(FindLocationRequest request);
    }
}
