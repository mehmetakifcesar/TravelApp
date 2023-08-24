using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DAL.Concrete.EntityFramework.Mapping;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Context
{
    public class TravelAppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=LAPTOP-01AQLBG9\\AKIF; initial catalog= TravelApp; integrated security= True; TrustServerCertificate=true");
            }
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new TourMap());
            modelBuilder.ApplyConfiguration(new TourGuideMap());
            modelBuilder.ApplyConfiguration(new TourCompanyMap());
            modelBuilder.ApplyConfiguration(new ReservationDetailMap());
            modelBuilder.ApplyConfiguration(new ReservationMap());
            modelBuilder.ApplyConfiguration(new DestinationMap());
            modelBuilder.ApplyConfiguration(new FlightInformationMap());
            modelBuilder.ApplyConfiguration(new HotelMap());
            base.OnModelCreating(modelBuilder);
        }



    }
}
