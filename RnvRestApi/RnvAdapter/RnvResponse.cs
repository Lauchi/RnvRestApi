using System.Net;
using System.Net.Http;

namespace RnvRestApi.RnvAdapter
{
    public class RnvResponse
    {
        private readonly HttpResponseMessage _httpResponseMessage;

        public RnvResponse(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
        }

        public HttpContent Content => _httpResponseMessage.Content;
        public HttpStatusCode StatusCode => _httpResponseMessage.StatusCode;
    }
}