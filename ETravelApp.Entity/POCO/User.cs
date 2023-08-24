using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.Entity.POCO
{
    public class User:AuditableEntity
    {
        public User()
        {
            Reservations=new HashSet<Reservation>();
        }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }

        public virtual IEnumerable<Reservation> Reservations { get; set; }


    }
}
