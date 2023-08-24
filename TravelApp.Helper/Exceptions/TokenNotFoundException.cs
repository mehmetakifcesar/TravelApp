using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.Helper.Exceptions
{
    public class TokenNotFoundException:Exception
    {
        public TokenNotFoundException(string message="Token Bulunamadı"):base(message) 
        {

        }

    }
}
