using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.ReservationDetail
{
    public class ReservationDetailUpdateDTORequest
    {
        public DateTime DateTime { get; set; }
        public int ReservationID { get; set; }
        public double TotalPrice { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }

    }
}
