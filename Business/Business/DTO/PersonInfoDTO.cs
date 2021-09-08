using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessInfoDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Status")]
        public int Status { get; set; }
        [JsonPropertyName("CreateTime")]
        public DateTime CreateTime { get; set; }
        [JsonPropertyName("Director")]
        public string Director { get; set; }
    }
}
