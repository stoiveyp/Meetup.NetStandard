using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Meetup.NetStandard.Response.Meta;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    internal class MetaCalls:IMeetupMeta
    {
        private readonly MeetupClientOptions _options;

        internal MetaCalls(MeetupClientOptions options)
        {
            _options = options;
        }

        public async Task<MeetupResponse<Status>> Status()
        {
            var response = await MeetupRequestMethods.GetAsync("/status",_options);
            return await response.AsObject<Status>(_options);
        }
    }
}
