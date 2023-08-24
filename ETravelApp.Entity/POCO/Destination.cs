using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class Destination:AuditableEntity
    {
        public Destination()
        {
            Tours = new HashSet<Tour>();
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        
        public virtual IEnumerable<Tour> Tours { get; set; }
    }
}
