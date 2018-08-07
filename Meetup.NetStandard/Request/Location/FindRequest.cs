using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Meetup.NetStandard.Request.Location
{
    internal class FindRequest:IFindRequest,IFindCoordinateRequest,IFindNameRequest,IFindExecutor
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

        public IFindRequest WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        IFindExecutor IFindRequestPager<IFindExecutor>.OnPage(int page)
        {
            Page = page;
            return this;
        }

        public async Task<FindResponse> Execute()
        {
            throw new NotImplementedException();
        }

        IFindExecutor IFindRequestPager<IFindExecutor>.WithPageSize(int pageSize)
        {
            throw new NotImplementedException();
        }

        IFindNameRequest IFindRequestPager<IFindNameRequest>.OnPage(int page)
        {
            Page = page;
            return this;
        }

        public IFindExecutor AndByCoordinate(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            return this;
        }

        public IFindExecutor AndByName(string name)
        {
            Query = name;
            return this;
        }

        public IFindExecutor AndByCoordinate(int longitude, int latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            return this;
        }

        IFindNameRequest IFindRequestPager<IFindNameRequest>.WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        IFindCoordinateRequest IFindRequestPager<IFindCoordinateRequest>.OnPage(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        IFindCoordinateRequest IFindRequestPager<IFindCoordinateRequest>.WithPageSize(int pageSize)
        {
            PageSize = pageSize;
            return this;
        }

        public IFindRequest OnPage(int page)
        {
            Page = page;
            return this;
        }

        public IFindCoordinateRequest ByCoordinate(double longitude, double latitude)
        {
            Longitude = longitude;
            Latitude = latitude;
            return this;
        }

        public IFindNameRequest ByName(string name)
        {
            Query = name;
            return this;
        }
    }
}
