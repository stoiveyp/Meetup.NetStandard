using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Meetup.NetStandard.Response.Profiles
{
    public enum ProfileStatus
    {
        [EnumMember(Value="active")]
        Active,
        [EnumMember(Value = "prereg")]
        PreReg,
        [EnumMember(Value = "unknown")]
        Unknown
    }
}
