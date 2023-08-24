using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.Destination
{
    public class DestinationUpdateDTORequest
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }

    }
}
