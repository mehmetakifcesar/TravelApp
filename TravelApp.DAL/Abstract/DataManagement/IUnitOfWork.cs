using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelApp.DAL.Abstract.DataManagement
{
    public interface IUnitOfWork
    {
        IUserRepository UserRepository{ get; }
        ITourRepository TourRepository { get; }
        ITourCompanyRepository TourCompanyRepository { get; }
        IReservationDetailRepository ReservationDetailRepository { get; }
        IReservationRepository ReservationRepository { get; }
        IHotelRepository HotelRepository { get; }
        IFlightInformationRepository FlightInformationRepository { get; }
        ITourGuideRepository TourGuideRepository { get; }
        IDestinationRepository DestinationRepository { get; }
        Task<int> SaveChangeAsync();
    }
}
