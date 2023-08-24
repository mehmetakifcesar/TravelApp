using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Business.Abstract.GenericService;
using TravelApp.Entity.POCO;

namespace TravelApp.Business.Abstract
{
    public interface IUserService:IGenericService<User>
    {

    }
}
