using Microsoft.EntityFrameworkCore;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Concrete.EntityFramework.DataManagement;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework
{
    public class EFFlightInformationRepository : EFRepository<FlightInformation>, IFlightInformationRepository
    {
        public EFFlightInformationRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
