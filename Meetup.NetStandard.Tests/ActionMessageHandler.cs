using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Meetup.NetStandard.Tests
{
    public class ActionMessageHandler : HttpMessageHandler
    {
        private Func<HttpRequestMessage, Task<HttpResponseMessage>> Action { get; }

        public ActionMessageHandler(Func<HttpRequestMessage, HttpResponseMessage> action)
        {
            Action = r => Task.FromResult(action(r));
        }

        public ActionMessageHandler(Func<HttpRequestMessage, Task<HttpResponseMessage>> action)
        {
            Action = action;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            return Action(request);
        }
    }
}
