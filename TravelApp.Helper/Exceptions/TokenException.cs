using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Helper.Exceptions
{
    public class TokenException:Exception
    {
        public TokenException(string message="Token Hatası") :base(message) 
        { 
        }
    }
}
