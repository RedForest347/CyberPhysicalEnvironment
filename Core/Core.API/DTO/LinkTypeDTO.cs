using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.API
{
    public class LinkTypeDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Code")]
        public int Code { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        //public List<LinkDTO> Links { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }


    }
}
