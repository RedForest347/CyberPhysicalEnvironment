using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Core.API
{
    public class LinkDTO
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }
        [JsonPropertyName("ActiveLinkFlag")]
        public bool ActiveLinkFlag { get; set; } //Связь является актуальной
        [JsonPropertyName("Agent1Checked")]
        public bool Agent1Checked { get; set; } //Подтверждена агентом 1
        [JsonPropertyName("Agent2Checked")]
        public bool Agent2Checked { get; set; } //Подтверждена агентом 2
        [JsonPropertyName("CheckedTime")]
        public DateTime CheckedTime { get; set; } //Время подтверждения
        [JsonPropertyName("CloseTime")]
        public DateTime CloseTime { get; set; } //Время завершения связи
        [JsonPropertyName("RequestTime")]
        public DateTime RequestTime { get; set; } //Время запроса на установление связи
        [JsonPropertyName("Description")]
        public string Description { get; set; }
        [JsonPropertyName("Status")]
        public int Status { get; set; } //Статус связи


        //внешние ключи
        [JsonPropertyName("Agent1Id")]
        public Guid Agent1Id { get; set; }
        [JsonPropertyName("Agent2Id")]
        public Guid Agent2Id { get; set; }
        [JsonPropertyName("LinkTypeId")]
        public Guid LinkTypeId { get; set; }
        //Свойства навигации
        public AgentDTO Agent1 { get; set; } // передается пустым // от кого исходит связь
        public AgentDTO Agent2 { get; set; } // передается пустым // к кому идет связь
        [JsonPropertyName("LinkType")]
        public LinkTypeDTO LinkType { get; set; }
    }
}
