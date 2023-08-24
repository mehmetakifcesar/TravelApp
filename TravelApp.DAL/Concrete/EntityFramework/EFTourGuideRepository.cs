using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFTourGuideRepository : EFRepository<TourGuide>, ITourGuideRepository
    {
        public EFTourGuideRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
