using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class AgentType
    {
        public Guid Id { get; set; }
        public int Code { get; set; } // 1 - P, 2 - B, 3 - M
        public string Description { get; set; }
        public string Name { get; set; } // Person, Business, Machinery


        //Свойства навигации
        public List<Agent> Agents { get; set; } = new List<Agent>();

    }
}
