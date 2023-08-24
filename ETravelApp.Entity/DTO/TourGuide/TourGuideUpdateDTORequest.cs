using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.TourGuide
{
    public class TourGuideUpdateDTORequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }
    }
}
