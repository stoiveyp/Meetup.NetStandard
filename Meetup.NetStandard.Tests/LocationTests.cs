using System;
using System.Collections.Generic;
using System.Text;
using Meetup.NetStandard.Request.Location;
using Xunit;
using Xunit.Abstractions;

namespace Meetup.NetStandard.Tests
{
    public class LocationTests
    {
        private const string TestToken = "testToken";

        [Fact]
        public void LocationCreatedCorrectly()
        {
            var meetup = MeetupClient.WithApiToken(TestToken);
            Assert.NotNull(meetup.Location);
        }

        [Fact]
        public void LocationFindReturnsRequestInterface()
        {
            var meetup = MeetupClient.WithApiToken("testToken");
            var fluentStepOne = meetup.Location.Find();
            Assert.NotNull(fluentStepOne);
        }

        [Fact]
        public void IFindRequestAssertions()
        {
            var find = new FindRequest(null);
            var ifind = (IFindRequest) find;
            ifind.ByCoordinate(20.0, 45.3);
            Assert.Equal(20.0,find.Longitude);
            Assert.Equal(45.3,find.Latitude);

            ifind.ByName("test");
            Assert.Equal("test",find.Query);

            ifind.OnPage(1);
            Assert.Equal(1,find.Page);

            ifind.WithPageSize(20);
            Assert.Equal(20,find.PageSize);
        }

        [Fact]
        public void IFindNameAssertions()
        {
            var find = new FindRequest(null);
        }
    }
}
