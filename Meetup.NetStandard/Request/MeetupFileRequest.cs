using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Meetup.NetStandard.Request
{
    public abstract class MeetupFileRequest:MeetupRequest
    {
        public abstract IEnumerable<KeyValuePair<string, Stream>> GetFiles();
    }
}
