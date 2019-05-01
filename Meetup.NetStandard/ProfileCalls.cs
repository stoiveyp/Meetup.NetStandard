using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Meetup.NetStandard.Request.Profiles;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Groups;
using Meetup.NetStandard.Response.Profiles;

namespace Meetup.NetStandard
{
    internal class ProfileCalls:IMeetupProfiles
    {
        private readonly MeetupClientOptions _options;
        internal ProfileCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public Task<MeetupResponse<Profile>> Get()
        {
            return MeetupRequestMethods.GetAsync<Profile>("/members/self", _options);
        }

        public Task<Profile> Update(Group group, ProfileUpdate update)
        {
            if (group == null)
            {
                throw new ArgumentNullException(nameof(group));
            }
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update));
            }
            return Update(group.UrlName, update);
        }

        public Task<Profile> Update(string urlName, ProfileUpdate update)
        {
            if (urlName == null)
            {
                throw new ArgumentNullException(nameof(urlName));
            }
            if (update == null)
            {
                throw new ArgumentNullException(nameof(update));
            }
            var data = new Dictionary<string, string>();

            if (update.PhotoId.HasValue)
            {
                data.Add("photo_id",update.PhotoId.ToString());
            }

            if(update.Bio != null)
            {
                data.Add("bio",update.Bio);
            }

            return MeetupRequestMethods.PatchAsync<Profile>($"/{urlName}/members/self", _options, data);
        }
    }
}
