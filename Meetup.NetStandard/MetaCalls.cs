using System.Net.Http;
using System.Threading.Tasks;
using Meetup.NetStandard.Response;
using Newtonsoft.Json;

namespace Meetup.NetStandard
{
    internal class MetaCalls:IMeetupMeta
    {
        private readonly HttpClient _client;
        private readonly JsonSerializer _serializer;

        internal MetaCalls(HttpClient client,JsonSerializer serializer)
        {
            _client = client;
            _serializer = serializer;
        }

        public async Task<MeetupResponse<Status>> Status(MeetupRequestOptions options = null)
        {
            var requestMessage = options ?? new MeetupRequestOptions();
            var response = await requestMessage.GetAsync("/status",_client);
            return await response.AsObject<Status>(_serializer);
        }
    }
}
