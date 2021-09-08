using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Machinery
{
    public class MachineryInfoDTO
    {
        [JsonPropertyName("Id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Code")]
        public string Code { get; set; }
        [JsonPropertyName("Status")]
        public int Status { get; set; }
        [JsonPropertyName("CreateTime")]
        public DateTime CreateTime { get; set; }
        [JsonPropertyName("VerificationTime")]
        public DateTime VerificationTime { get; set; }
        [JsonPropertyName("LastVerificationTime")]
        public DateTime LastVerificationTime { get; set; }
        [JsonPropertyName("EndWorkTime")]
        public DateTime EndWorkTime { get; set; }
    }
}
