using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Helper.Globals
{
    public class JWTExceptURL
    {
        public List<string> URLList { get; set; }
        public JWTExceptURL()
        {
            URLList = new List<string>();
            URLList.Add("/Login");
        }
    }
}
