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
        public async Task FindTopicCategoriesUsesDataCorrectly()
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

        [Fact]
        public async Task FindTopicUsesCorrectUrl()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/topics?photo-host=public&query=tech")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Topics.Find("tech");
        }

        [Fact]
        public async Task FindTopicThrowsIfQueryIsEmpty()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/topics?photo-host=public&query=tech")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Topics.Find(string.Empty));
        }

        [Fact]
        public async Task FindTopicUsesDataCorrectly()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertResponse("Topics")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var response = await meetup.Topics.Find("tech");

            Assert.Equal(3,response.Data.Length);
            var topic = response.Data.Skip(1).First();

            Assert.Equal(10579, topic.Id);
            Assert.Equal("Technology",topic.Name);
            Assert.Equal("technology",topic.UrlKey);
            Assert.Equal("Meetup with other people interested in the internet and technology!",topic.Description);
            Assert.Equal(6981,topic.GroupCount);
            Assert.Equal(4927597,topic.MemberCount);
            Assert.Equal("en_US",topic.LanguageCode);
        }

        [Fact]
        public async Task RecommendedTopicThrowsIfQueryIsEmpty()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/topics?photo-host=public&query=tech")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Topics.RecommendedGroupTopic(string.Empty));
            Assert.Equal("text",exception.ParamName);
        }

        [Fact]
        public async Task RecommendedTopicThrowsIfGroupsListIsEmpty()
        {
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/find/topics?photo-host=public&query=tech")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            var exception = await Assert.ThrowsAsync<ArgumentNullException>(() => meetup.Topics.RecommendedGroupTopic(new int[]{}));
            Assert.Equal("basedOnTopics", exception.ParamName);
        }

        [Fact]
        public async Task RecommendedTopicGeneratesCorrectUrl()
        {
            var request = new RecommendedGroupTopicRequest("tech")
            {
                LanguageCode="en_US",
                OtherTopics = new []{45},
                ExcludeTopics = new[] {123},
                NumberOfResults=20
            };

            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertUrl("/recommended/group_topics?photo-host=public&text=tech&other_topics=45&exclude_topics=123&lang=en_US&page=20")
            };

            var meetup = MeetupClient.WithApiToken("testToken", options);
            await meetup.Topics.RecommendedGroupTopic(request);
        }
    }
}
