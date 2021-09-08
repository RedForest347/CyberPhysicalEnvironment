using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Machinery.Domain
{
    public class MachineryInfo
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Status { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime VerificationTime { get; set; }
        public DateTime LastVerificationTime { get; set; }
        public DateTime EndWorkTime { get; set; }
        
        





    }
}
