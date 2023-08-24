using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace TravelApp.Helper.Exceptions
{
    public class FieldValidationException:Exception
    {
        public FieldValidationException(List<string> validationMessages)
        {
            base.Data["FieldValidationErrors"] = validationMessages;
        }
    }
}
