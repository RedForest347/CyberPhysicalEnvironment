using Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Client
{
    public class AgentService : ServiceBase<AgentDTO>
    {
        public AgentService(HttpClient client) : base(client, "api/agent")
        {
            //Console.WriteLine("client " + client.BaseAddress + "api/agent");
        }
    }

}
