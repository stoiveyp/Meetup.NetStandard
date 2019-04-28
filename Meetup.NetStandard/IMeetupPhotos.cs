using System.IO;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Photos;
using Meetup.NetStandard.Response;

namespace Meetup.NetStandard
{
    public interface IMeetupPhotos
    {
        Task<MeetupResponse<MeetupPhoto>> Update(UpdatePhotoRequest request);
    }
}