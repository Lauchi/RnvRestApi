using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace RnvRestApi.rnvAdapter
{
    public class RnvClient
    {
        private readonly HttpClient _client;

        public RnvClient(HttpClient client)
        {
            _client = client;
        }

        public IRnvCommand RnvCommand { get; set; }

        public async Task<RnvResponse> SendRequest()
        {
            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            var xmlRepresentation = Encoding.UTF8.GetBytes(RnvCommand.GetXmlRepresentation());
            httpRequestMessage.Content = new ByteArrayContent(xmlRepresentation);
            var httpResponseMessage = await _client.SendAsync(httpRequestMessage);
            return new RnvResponse(httpResponseMessage);
        }
    }
}