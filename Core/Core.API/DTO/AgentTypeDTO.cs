using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.API
{
    public class AgentTypeDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Code")]
        public int Code { get; set; }
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }


        //Свойства навигации
        //public List<AgentDTO> Agents { get; set; } = new List<AgentDTO>();
    }
}
