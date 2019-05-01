using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class GroupTests
    {
        [Fact]
        public void GroupCallsGeneratedCorrectly()
        {
            var meetup = MeetupClient.WithOAuthToken("testToken");
            Assert.NotNull(meetup.Groups);
        }

        [Fact]
        public async Task GetThrowsExceptionOnEmptyGroupName()
        {
            var meetup = MeetupClient.WithOAuthToken("testToken");
            var error = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Groups.Get(string.Empty));
            Assert.Equal("groupName",error.ParamName);
        }

        [Fact]
        public async Task GetGroupGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham")
            };
            var meetup = MeetupClient.WithOAuthToken("testToken",options);
            await meetup.Groups.Get("tech-nottingham");
        }

        [Fact]
        public async Task GetGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/self/groups")
            };
            var meetup = MeetupClient.WithOAuthToken("testToken", options);
            await meetup.Groups.Get();
        }

        [Fact]
        public async Task GetWithFieldsGeneratesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/tech-nottingham?fields=plain_text_no_images_description")
            };
            var meetup = MeetupClient.WithOAuthToken("testToken", options);
            await meetup.Groups.Get("tech-nottingham",new []{ "plain_text_no_images_description" });
        }

        [Fact]
        public async Task GetGeneratesCorrectData()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("Group")
            };
            var meetup = MeetupClient.WithOAuthToken("testToken", options);
            var response = await meetup.Groups.Get("tech-nottingham");
            var data = response.Data;

            Assert.Equal(14171002,data.Id);
            Assert.Equal("Tech Nottingham",data.Name);
            Assert.Equal(MeetupVisibility.Public,data.Visibility);
            Assert.NotNull(data.Organizer);
            Assert.Equal(202648061,data.Organizer.Id);
        }
    }
}
