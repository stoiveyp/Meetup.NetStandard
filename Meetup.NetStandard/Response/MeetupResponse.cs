using System.Linq;
using System.Net.Http;

namespace Meetup.NetStandard.Response
{
    public class MeetupResponse
    {
        public const string RateLimitHeader = "X-RateLimit-Limit";
        public const string RateLimitRemainingHeader = "X-RateLimit-Remaining";
        public const string RateLimitResetSecondsHeader = "X-RateLimit-Reset";

        public int? RateLimit { get; }
        public int? RateLimitRemaining { get; }
        public int? RateLimitResetSeconds { get; }

        public MeetupResponse(HttpResponseMessage response)
        {
            RateLimit = GetInt(response, RateLimitHeader);
            RateLimitRemaining = GetInt(response, RateLimitRemainingHeader);
            RateLimitResetSeconds = GetInt(response, RateLimitResetSecondsHeader);
        }

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