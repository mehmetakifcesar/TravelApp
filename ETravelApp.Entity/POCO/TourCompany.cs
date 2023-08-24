using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class TourCompany:AuditableEntity
    {
        public TourCompany()
        {
            Tours = new HashSet<Tour>();
        }
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public virtual IEnumerable<Tour> Tours { get; set; }
    }
}
