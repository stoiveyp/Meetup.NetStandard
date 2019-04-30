using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Photos;
using Meetup.NetStandard.Tests.Helpers;
using Xunit;

namespace Meetup.NetStandard.Tests
{
    public class PhotoTests
    {
        private const string TestToken = "testToken";

        [Fact]
        public void PhotosCreatedCorrectly()
        {
            var meetup = MeetupClient.WithOAuthToken(TestToken);
            Assert.NotNull(meetup.Photos);
        }

        [Fact]
        public async Task PhotoUpdateGeneratesCorrectForm()
        {
            var bytes = new byte[] {1, 2, 3, 4, 5, 6, 7, 8};
            var memStream = new MemoryStream(bytes);
            var options = new MeetupClientOptions
            {
                Client = FakeHttpClient.AssertMultiPartFormDataContent(
                    "/members/self/photos",
                    new Dictionary<string, string>(),
                    new Dictionary<string, Stream> {{"photo", new MemoryStream(bytes)}}
            )};

            var meetup = MeetupClient.WithOAuthToken(TestToken,options);
            await meetup.Photos.Update(new UpdatePhotoRequest(memStream,"test.jpg"));
        }
    }
}
