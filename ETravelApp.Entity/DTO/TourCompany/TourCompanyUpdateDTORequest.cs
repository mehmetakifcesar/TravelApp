using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Entity.DTO.TourCompany
{
    public class TourCompanyUpdateDTORequest
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid Guid { get; set; }
        public bool? IsActive { get; set; }

    }
}
