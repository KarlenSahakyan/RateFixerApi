using Microsoft.AspNetCore.Mvc;
using RateFixerLibrary.Helpers;

namespace RateFixerApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RateController : ControllerBase
    {
        private IRequestService _requestService;

        public RateController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [HttpPost(Name = "GetLatestRates")]
        public async Task<string> GetLatestRates() => await _requestService.GetHttpRequest(HttpMethod.Get, "/latest");

    }
}
