using System;
using System.Collections.Generic;

namespace Meetup.NetStandard.Request
{
    public class MeetupRequest
    {
        public string ContextGroupName { get; set; }
        public string ContextEventId { get; set; }

        public virtual Dictionary<string, string> AsDictionary(){
            return new Dictionary<string,string>();
        }
    }
}
