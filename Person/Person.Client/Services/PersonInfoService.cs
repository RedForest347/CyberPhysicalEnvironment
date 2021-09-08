using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Person.Client
{
    public class PersonInfoService : ServiceBase<PersonInfoDTO>
    {
        public PersonInfoService(HttpClient client) : base(client, "api/person")
        {
            
        }
    }
}
