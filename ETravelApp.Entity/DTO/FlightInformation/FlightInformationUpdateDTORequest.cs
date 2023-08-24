using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.FlightInformation
{
    public class FlightInformationUpdateDTORequest
    {
        public string Airline { get; set; }
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureDate { get; set; }
        public DateTime ArrivalDate { get; set; }
        public double Price { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }


    }
}
