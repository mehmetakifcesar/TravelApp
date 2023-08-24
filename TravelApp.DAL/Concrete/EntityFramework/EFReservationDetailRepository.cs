using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFReservationDetailRepository : EFRepository<ReservationDetail>, IReservationDetailRepository
    {
        public EFReservationDetailRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
