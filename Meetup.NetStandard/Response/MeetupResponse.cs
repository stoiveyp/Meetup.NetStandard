using System.Linq;
using System.Net.Http;

namespace Meetup.NetStandard.Response
{
    public class MeetupResponse<T>:MeetupResponse
    {
        public T Data { get; }
        public int? RateLimit { get; }
        public int? RateLimitRemaining { get; }
        public int? RateLimitResetSeconds { get; }

        public MeetupResponse(HttpResponseMessage response, T data)
        {
            RateLimit = GetInt(response, RateLimitHeader);
            RateLimitRemaining = GetInt(response, RateLimitRemainingHeader);
            RateLimitResetSeconds = GetInt(response, RateLimitResetSecondsHeader);

            Data = data;
        }
    }

    public class MeetupResponse
    {
        public const string RateLimitHeader = "X-RateLimit-Limit";
        public const string RateLimitRemainingHeader = "X-RateLimit-Remaining";
        public const string RateLimitResetSecondsHeader = "X-RateLimit-Reset";

        protected static int? GetInt(HttpResponseMessage message, string header)
        {
            if (!message.Headers.Contains(header))
            {
                return null;
            }

            if (int.TryParse(message.Headers.GetValues(header).First(), out var headerValue))
            {
                return headerValue;
            }

            return null;
        }
    }
}