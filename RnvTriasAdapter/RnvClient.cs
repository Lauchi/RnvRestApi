﻿using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using RnvTriasAdapter.RnvCommands;

namespace RnvTriasAdapter
{
    public class RnvClient
    {
        private readonly HttpClient _client;

        public RnvClient(HttpClient client)
        {
            _client = client;
        }

        public async Task<RnvResponse> SendRequest(RnvCommand rnvCommand)
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            var xmlRepresentation = Encoding.UTF8.GetBytes(rnvCommand.GetXmlRepresentation());
            httpRequestMessage.Content = new ByteArrayContent(xmlRepresentation);
            var httpResponseMessage = await _client.SendAsync(httpRequestMessage);
            return new RnvResponse(httpResponseMessage);
        }
    }
}