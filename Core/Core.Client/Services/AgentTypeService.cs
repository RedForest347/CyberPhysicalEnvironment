using Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Client
{
    public class AgentTypeService : ServiceBase<AgentTypeDTO>
    {
        public AgentTypeService(HttpClient client) : base(client, "api/agentType")
        {

        }

        public override Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            throw new Exception("Функция не определена");
        }


        public override Task<HttpResponseMessage> PutAsync(Guid id, AgentTypeDTO DTO)
        {
            throw new Exception("Функция не определена");
        }

        public override Task<HttpResponseMessage> PostAsync(AgentTypeDTO DTO)
        {
            throw new Exception("Функция не определена");
        }

    }
}
