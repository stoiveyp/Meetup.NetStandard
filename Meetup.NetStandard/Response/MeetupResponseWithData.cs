using System.Net.Http;

namespace Meetup.NetStandard.Response
{
    public class MeetupResponse<T>:MeetupResponse
    {
        public T Data { get; }
        public MeetupLink<T> Previous { get; private set; }
        public MeetupLink<T> Next { get; private set; }

        public MeetupResponse(HttpResponseMessage response, T data):base(response)
        {
            Data = data;
        }
    }
}