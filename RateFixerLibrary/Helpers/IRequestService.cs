using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RateFixerLibrary.Helpers
{
    public interface IRequestService
    {
        Task<string> GetHttpRequest(HttpMethod requestMethod,string uri);
    }
}
