using System;
using System.Net;

namespace Meetup.NetStandard
{
    public class MeetupException : Exception
    {
        public HttpStatusCode StatusCode { get; }
        public MeetupError[] Errors {get;}
        public MeetupException(HttpStatusCode statusCode, MeetupError[] errors = null)
        {
            StatusCode = statusCode;
            Errors = errors ?? new MeetupError[]{};
        }
    }
}