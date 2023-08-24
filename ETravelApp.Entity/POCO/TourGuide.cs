using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class TourGuide:AuditableEntity
    {
        public TourGuide()
        {
            Tours = new HashSet<Tour>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public virtual IEnumerable<Tour> Tours { get; set; }
    }
}
