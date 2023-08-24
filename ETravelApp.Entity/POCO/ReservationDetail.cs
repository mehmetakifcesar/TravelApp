using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class ReservationDetail:AuditableEntity
    {
       
        public Tour Tour { get; set; }
        public DateTime DateTime { get; set; }
        public int ReservationID { get; set; }
        public double TotalPrice { get; set; }
        public virtual Reservation Reservation { get; set; }
    }
}
