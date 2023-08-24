using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.DTO.Base;

namespace TravelApp.Entity.DTO.ReservationDetail
{
    public class ReservationDetailDTOBase:BaseDTO
    {
       
        public DateTime DateTime { get; set; }
        public int ReservationID { get; set; }
        public double TotalPrice { get; set; }
    }
}
