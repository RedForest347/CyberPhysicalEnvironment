using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Person.Domain
{
    public class PersonInfo
    {
        //[JsonPropertyName("Id")]
        public Guid Id { get; set; }
        //[JsonPropertyName("Name")]
        public string Name { get; set; }
        //[JsonPropertyName("Pasport")]
        public string Pasport { get; set; }
        //[JsonPropertyName("INN")]
        public string INN { get; set; }
        //[JsonPropertyName("Sex")]
        public string Sex { get; set; }
        //[JsonPropertyName("Mail")]
        public string Mail { get; set; }
        //[JsonPropertyName("CreateTime")]
        public DateTime CreateTime { get; set; }
        //[JsonPropertyName("Status")]
        public int Status { get; set; }





    }
}
