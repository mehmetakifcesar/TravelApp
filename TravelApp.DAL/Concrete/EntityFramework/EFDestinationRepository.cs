using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFDestinationRepository : EFRepository<Destination>, IDestinationRepository
    {
        public EFDestinationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
