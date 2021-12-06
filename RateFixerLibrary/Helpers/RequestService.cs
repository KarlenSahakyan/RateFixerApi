using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
namespace RateFixerLibrary.Helpers
{
    public class RequestService : IRequestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;
        public RequestService(IHttpClientFactory clientFactory, IConfiguration config)
        {
            _clientFactory = clientFactory;
            _config = config;
        }
        async Task<string> IRequestService.GetHttpRequest(HttpMethod requestMethod, string endpoint)
        {
            var request = new HttpRequestMessage(requestMethod, endpoint + "?access_key=" + _config["FixedApiAccessToken"]);
            var client = _clientFactory.CreateClient("FixerApi");
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();

                using var sr = new StreamReader(responseStream);
                return await sr.ReadToEndAsync();

            }
            else
            {

            }
            return "";
        }
    }
}
