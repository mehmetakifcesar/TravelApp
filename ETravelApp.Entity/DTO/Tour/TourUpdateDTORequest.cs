using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.Tour
{
    public class TourUpdateDTORequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime EndingDate { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }


    }
}
