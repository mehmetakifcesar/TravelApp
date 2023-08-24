using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.Base
{
    public class AuditableEntity:BaseEntity
    {
        public DateTime AddedTime { get; set; }
        public DateTime UpdatedTime { get; set;}
        public int AddedUser { get; set; }
        public int UpdatedUser { get; set;}
        public string AddedIPV4Address { get; set; }
        public string UpdatedIPV4Address { get;set; }
    }
}
