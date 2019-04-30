using System;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Photos;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public class PhotosCalls : IMeetupPhotos
    {
        private readonly MeetupClientOptions _options;
        internal PhotosCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public Task<MeetupPhoto> Update(UpdatePhotoRequest request)
        {
            return MeetupRequestMethods.PostWithFilesAsync<MeetupPhoto>("/members/self/photos", _options, request);
        }
    }
}
