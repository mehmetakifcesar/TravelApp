using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class Tour:AuditableEntity
    {
        public Tour()
        {
            Destinations = new HashSet<Destination>();
            Reservations = new HashSet<Reservation>();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public virtual IEnumerable<Destination> Destinations { get; set; }
        public virtual TourGuide TourGuide { get; set; }
        public virtual TourCompany TourCompany { get; set; }
        public virtual IEnumerable<Reservation> Reservations { get; set; }
    }
}
