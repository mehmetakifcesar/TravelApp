using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFHotelRepository : EFRepository<Hotel>, IHotelRepository
    {
        public EFHotelRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
