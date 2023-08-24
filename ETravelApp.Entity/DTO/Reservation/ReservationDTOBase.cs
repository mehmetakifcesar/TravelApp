using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.DTO.Base;

namespace TravelApp.Entity.DTO.Reservation
{
    public class ReservationDTOBase:BaseDTO
    {
        public DateTime ReservationDate { get; set; }
        public int NumberOfTravelers { get; set; }
        public double Price { get; set; }
        public int UserID { get; set; }
    }
}
