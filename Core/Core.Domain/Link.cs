using System;

namespace Core.Domain
{
    public class Link
    {
        public Guid Id { get; set; }
        public bool ActiveLinkFlag { get; set; } //Связь является актуальной
        public bool Agent1Checked { get; set; } //Подтверждена агентом 1
        public bool Agent2Checked { get; set; } //Подтверждена агентом 2
        public DateTime CheckedTime { get; set; } //Время подтверждения
        public DateTime CloseTime { get; set; } //Время завершения связи
        public DateTime RequestTime { get; set; } //Время запроса на установление связи
        public string Description { get; set; }
        public int Status { get; set; } //Статус связи


        //Внешние ключи
        public Guid LinkTypeId { get; set; }
        public Guid Agent1Id { get; set; }
        public Guid Agent2Id { get; set; }

        //Свойства навигации
        public LinkType LinkType { get; set; }
        public Agent Agent1 { get; set; }
        public Agent Agent2 { get; set; }
        

    }
}
