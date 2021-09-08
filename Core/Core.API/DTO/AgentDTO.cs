using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Core.API
{
    public class AgentDTO
    {
        //скачлярные свойства
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("Descripion")]
        public string Description { get; set; }
        [JsonPropertyName("Name")]
        public string Name { get; set; }
        [JsonPropertyName("Status")]
        public int Status { get; set; } //Статус агента
        [JsonPropertyName("RegisterTime")]
        public DateTime RegisterTime { get; set; } //Время регистрации агента
        [JsonPropertyName("ImgURL")]
        public string ImgURL { get; set; }

        //внешние ключи
        [JsonPropertyName("ObjectId")]
        public Guid ObjectId { get; set; } // Идентификатор AgentInfo


        //Свойства навигации
        [JsonPropertyName("AgentType")]
        public AgentTypeDTO AgentTypeDto { get; set; }
        [JsonPropertyName("InputLinks")]
        public List<LinkDTO> InputLinks { get; set; } = new List<LinkDTO>();
        [JsonPropertyName("OutputLinks")]
        public List<LinkDTO> OutputLinks { get; set; } = new List<LinkDTO>();

    }
}
