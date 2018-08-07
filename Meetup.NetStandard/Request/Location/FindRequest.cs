using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Response.Location;

namespace Meetup.NetStandard.Request.Location
{
    internal class FindRequest:IFindRequest,IFindRequestAdditional
    {
        internal double? Latitude { get; set; }
        internal double? Longitude { get; set; }
        internal string Query { get; set; }
        internal int? Page { get; set; }
        internal int? PageSize { get; set; }

        private readonly DefaultClientOptions _options;

        public FindRequest(DefaultClientOptions options)
        {
            _options = options;
        }

        IFindRequest IFindRequestPager<IFindRequest>.WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        IFindRequestAdditional IFindRequestPager<IFindRequestAdditional>.OnPage(int page)
        {
            Page = page;
            return this;
        }

        IFindRequestAdditional IFindRequestPager<IFindRequestAdditional>.WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        IFindRequest IFindRequestPager<IFindRequest>.OnPage(int page)
        {
            Page = page;
            return this;
        }

        async Task<FindResponse> IFindExecutor.Execute()
        {
            throw new NotImplementedException();
        }

        IFindRequestAdditional IFindRequest.ByName(string name)
        {
            Query = name;
            return this;
        }

        IFindRequestAdditional IFindRequest.ByCoordinate(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            return this;
        }

        IFindRequestAdditional IFindRequestAdditional.AndByName(string name)
        {
            Query = name;
            return this;
        }

        IFindRequestAdditional IFindRequestAdditional.AndByCoordinate(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            return this;
        }
    }
}
