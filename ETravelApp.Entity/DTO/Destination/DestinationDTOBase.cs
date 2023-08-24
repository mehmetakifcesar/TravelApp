using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.DTO.Base;

namespace TravelApp.Entity.DTO.Destination
{
    public class DestinationDTOBase:BaseDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
