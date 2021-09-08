using Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Client
{
    public class LinkService : ServiceBase<LinkDTO>
    {
        public HttpClient _httpClient;

        public LinkService(HttpClient client) : base (client, "api/link")
        {

        }

    }
}
