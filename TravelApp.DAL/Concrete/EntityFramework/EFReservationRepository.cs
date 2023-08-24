using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFReservationRepository : EFRepository<Reservation>, IReservationRepository
    {
        public EFReservationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
