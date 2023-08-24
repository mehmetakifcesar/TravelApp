using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFUserRepository : EFRepository<User>, IUserRepository
    {
        public EFUserRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
