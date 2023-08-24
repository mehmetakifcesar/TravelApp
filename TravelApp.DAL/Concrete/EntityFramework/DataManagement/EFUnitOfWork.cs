using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DAL.Abstract;
using TravelApp.DAL.Abstract.DataManagement;
using TravelApp.DAL.Concrete.EntityFramework.Context;
using TravelApp.DAL.Concrete.EntityFramework.Mapping;
using TravelApp.Entity.Base;

namespace TravelApp.DAL.Concrete.EntityFramework.DataManagement
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly TravelAppContext _appContext;
        private readonly IHttpContextAccessor _contextAccessor;

        public EFUnitOfWork(TravelAppContext appContext,IHttpContextAccessor contextAccessor)
        {
            _appContext = appContext;
            _contextAccessor = contextAccessor;
            UserRepository= new EFUserRepository(_appContext);
            TourCompanyRepository= new EFTourCompanyRepository(_appContext);
            TourGuideRepository= new EFTourGuideRepository(_appContext);
            TourRepository= new EFTourRepository(_appContext);
            HotelRepository = new EFHotelRepository(_appContext);
            ReservationDetailRepository= new EFReservationDetailRepository(_appContext);
            ReservationRepository= new EFReservationRepository(_appContext);
            FlightInformationRepository= new EFFlightInformationRepository(_appContext);
            DestinationRepository= new EFDestinationRepository(_appContext);
        }

        public IUserRepository UserRepository { get; }

        public ITourRepository TourRepository { get; }

        public ITourCompanyRepository TourCompanyRepository { get; }

        public IReservationDetailRepository ReservationDetailRepository { get; }

        public IReservationRepository ReservationRepository { get; }

        public IHotelRepository HotelRepository { get; }

        public IFlightInformationRepository FlightInformationRepository { get; }

        public ITourGuideRepository TourGuideRepository { get; }

        public IDestinationRepository DestinationRepository { get; }

        public async Task<int> SaveChangeAsync()
        {
            foreach (var item in _appContext.ChangeTracker.Entries<AuditableEntity>())
            {
                if (item.State == EntityState.Added)
                {
                    item.Entity.AddedTime = DateTime.Now;
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.AddedUser = 1;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.AddedIPV4Address = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    item.Entity.UpdatedIPV4Address = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                    if (item.Entity.IsActive == null)
                    {
                        item.Entity.IsActive = true;
                    }
                    item.Entity.IsDeleted = false;
                }
                else if (item.State == EntityState.Modified)
                {
                    item.Entity.UpdatedTime = DateTime.Now;
                    item.Entity.UpdatedUser = 1;
                    item.Entity.UpdatedIPV4Address = _contextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();

                }
            }
            return await _appContext.SaveChangesAsync();
        }
    }
}
