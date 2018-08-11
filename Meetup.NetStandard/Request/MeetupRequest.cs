using System;
using System.Collections.Generic;

namespace Meetup.NetStandard.Request
{
    public class MeetupRequest
    {
        public readonly Dictionary<string, string> _dictionary;

        public MeetupRequest(){}

        public MeetupRequest(Dictionary<string, string> querystring){
           _dictionary = querystring;
        }

        public string ContextGroupName { get; set; }
        public string ContextEventId { get; set; }

        public virtual Dictionary<string, string> AsDictionary(){
            return _dictionary ?? new Dictionary<string,string>();
        }

        public static MeetupRequest FieldsOnly(string fields)
        {
            return new MeetupRequest(new Dictionary<string,string>{{ "fields", fields }});
        }
    }
}
