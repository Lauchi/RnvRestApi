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
    }
}