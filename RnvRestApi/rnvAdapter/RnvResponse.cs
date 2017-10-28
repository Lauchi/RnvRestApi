using System.Net.Http;

namespace RnvRestApi.rnvAdapter
{
    public class RnvResponse
    {
        private readonly HttpResponseMessage _httpResponseMessage;

        public RnvResponse(HttpResponseMessage httpResponseMessage)
        {
            _httpResponseMessage = httpResponseMessage;
        }
    }
}