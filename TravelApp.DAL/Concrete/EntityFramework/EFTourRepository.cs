using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFTourRepository : EFRepository<Tour>, ITourRepository
    {
        public EFTourRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
