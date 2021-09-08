using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Agent
    {
        //скачлярные свойства
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }
        public DateTime RegisterTime { get; set; }
        public string ImgURL { get; set; }


        //внешние ключи
        public Guid ObjectId { get; set; } // Идентификатор AgentInfo
        public Guid AgentTypeId { get; set; }

        //Свойства навигации
        public AgentType AgentType { get; set; }
        public List<Link> InputLinks { get; set; } = new List<Link>();
        public List<Link> OutputLinks { get; set; } = new List<Link>();

    }
}
