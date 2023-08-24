using TravelApp.Entity.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class Reservation:AuditableEntity
    {
        public Reservation()
        {
            ReservationDetails =new HashSet<ReservationDetail>();
        }

        public DateTime ReservationDate { get; set; }
        public int NumberOfTravelers { get; set; }
        public double Price { get; set; }
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual FlightInformation FlightInformation { get; set; }
        public IEnumerable<ReservationDetail> ReservationDetails { get; set; }

    }
}
