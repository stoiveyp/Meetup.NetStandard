using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.NetStandard.Request.Profiles
{
    public class ProfileUpdate
    {
        public string Bio { get; set; }
        public int? PhotoId { get; set; }
    }
}
