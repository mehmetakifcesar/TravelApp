using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.Reservation
{
    public class ReservationUpdateDTORequest
    {
        public DateTime ReservationDate { get; set; }
        public int NumberOfTravelers { get; set; }
        public double Price { get; set; }
        public int UserID { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }

    }
}
