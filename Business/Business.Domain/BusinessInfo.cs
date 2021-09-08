using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business.Domain
{
    public class BusinessInfo
    {

        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public string Director { get; set; }





    }
}
