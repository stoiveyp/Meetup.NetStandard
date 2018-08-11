using System;
using System.Linq;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Topics;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class TopicTests
    {
        [Fact]
		public void TopicCallsCreatesCorrectly()
        {
            var api = MeetupClient.WithApiToken("testToken");
            Assert.NotNull(api.Topics);
        }

        [Fact]
        public async Task FindTopicCategoriesUsesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/topic_categories?photo-host=public")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Topics.FindCategories();
        }

        [Fact]
        public async Task FindTopicCategoriesUsesRequest()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/topic_categories?photo-host=public&lat=45.3&lon=-1.18&radius=23.4")
            };

            var request = new FindTopicCategoriesRequest
            {
                Latitude=45.3,
                Longitude=-1.18,
                MilesRadius=23.4
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Topics.FindCategories(request);
        }

        [Fact]
        public async Task FindTopicUsesDataCorrectly()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("TopicCategory")
            };

            var meetup = MeetupClient.WithApiToken("TestToken", options);
            var topics = await meetup.Topics.FindCategories();
            Assert.NotNull(topics.Data);
            Assert.Equal(3,topics.Data.Length);

            var topic = topics.Data.Skip(1).First();
            Assert.Equal("Tech",topic.Name);
            Assert.Equal("tech",topic.ShortName);
            Assert.Equal("Tech",topic.SortName);
            Assert.Equal(292,topic.Id);
            Assert.Single(topic.CategoryIds);
            Assert.NotNull(topic.Photo);

            Assert.Equal(450131949,topic.Photo.Id);
            Assert.Equal(MeetupPhotoType.Event,topic.Photo.Type);
            Assert.Equal("https://secure.meetupstatic.com/",topic.Photo.BaseUrl.ToString());
            Assert.Equal("https://secure.meetupstatic.com/photos/event/2/e/a/d/highres_450131949.jpeg", topic.Photo.HighRes.ToString());
            Assert.Equal("https://secure.meetupstatic.com/photos/event/2/e/a/d/600_450131949.jpeg", topic.Photo.Photo.ToString());
            Assert.Equal("https://secure.meetupstatic.com/photos/event/2/e/a/d/thumb_450131949.jpeg", topic.Photo.Thumb.ToString());
        }


    }
}
