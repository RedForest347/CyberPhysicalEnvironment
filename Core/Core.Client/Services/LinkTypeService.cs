using Core.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Core.Client
{
    public class LinkTypeService : ServiceBase<LinkTypeDTO>
    {
        public LinkTypeService(HttpClient client) : base(client, "api/linkType")
        {

        }


        public override Task<HttpResponseMessage> DeleteAsync(Guid id)
        {
            throw new Exception("Функция не определена");
        }

        public override Task<HttpResponseMessage> PutAsync(Guid id, LinkTypeDTO DTO)
        {
            throw new Exception("Функция не определена");
        }

        public override Task<HttpResponseMessage> PostAsync(LinkTypeDTO DTO)
        {
            throw new Exception("Функция не определена");
        }
    }
}
