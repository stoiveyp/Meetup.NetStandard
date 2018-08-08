﻿using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Geo;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Geo;

namespace Meetup.NetStandard
{
    internal class GeoCalls:IMeetupGeo
    {
        private readonly MeetupClientOptions _options;
        internal GeoCalls(MeetupClientOptions options)
        {
            _options = options;
        }
        public Task<MeetupResponse<Location[]>> FindLocation(string name)
        {
            return FindLocation(new FindLocationRequest {Name = name});
        }

        public Task<MeetupResponse<Location[]>> FindLocation(double longitude, double latitude)
        {
            return FindLocation(new FindLocationRequest {Longitude = longitude, Latitude = latitude});
        }

        public async Task<MeetupResponse<Location[]>> FindLocation(FindLocationRequest request)
        {
            var response = await MeetupRequestMethods.GetAsync("/find/location", _options,request.AsDictionary());
            return await response.AsObject<Location[]>(_options);
        }
    }
}
