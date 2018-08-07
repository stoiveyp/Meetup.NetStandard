using System.Net.Http;

namespace Meetup.NetStandard.Response
{
    public class MeetupResponse<T>:MeetupResponse
    {
        public T Data { get; }

        public MeetupResponse(HttpResponseMessage response, T data):base(response)
        {
            Data = data;
        }
    }
}