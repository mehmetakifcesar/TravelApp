using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class Hotel:AuditableEntity
    {
        public Hotel()
        {
            Reservations=new HashSet<Reservation>();
        }
        

        public string Name { get; set; }
        public string Adress { get; set; }
        public int NumberOfTravelers { get; set; }
        public DateTime ReservationDate { get; set; }

        public string Country { get; set; }
        public int RoomNumber { get; set; }
        public string City { get; set; }
        public double Price { get; set; }
        public IEnumerable<Reservation> Reservations { get; set; }
    }
}
