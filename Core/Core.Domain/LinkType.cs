using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class LinkType
    {
        public Guid Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }


        //Свойства навигации
        public List<Link> Links { get; set; } = new List<Link>();
        


    }
}
