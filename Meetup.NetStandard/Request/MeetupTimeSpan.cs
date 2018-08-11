using System;
namespace Meetup.NetStandard.Request
{
    public class MeetupTimeSpan
    {
        public string From { get; private set; }
        public string To { get; private set; }
        internal string ToUrl => $"{From},{To}";

        public MeetupTimeSpan(string from, string to)
        {
            if(string.IsNullOrWhiteSpace(from))
            {
                throw new ArgumentNullException(nameof(from));
            }

            if(string.IsNullOrWhiteSpace(to))
            {
                throw new ArgumentNullException(nameof(to));
            }

            From = from;
            To = to;
        }

        public MeetupTimeSpan(string from, int to):this(from,to.ToString())
        {

        }

        public MeetupTimeSpan(int from, int to):this(from.ToString(),to.ToString())
        {

        }
    }
}
