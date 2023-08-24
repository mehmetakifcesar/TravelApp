using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class ReservationMap : BaseMap<Reservation>
    {
        public virtual void Configure(EntityTypeBuilder<Reservation> builder)
        {
            builder.ToTable("Reservation");
            builder.Property(q => q.ReservationDate).HasMaxLength(50).IsRequired();
            builder.Property(q => q.NumberOfTravelers).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Price).HasMaxLength(50).IsRequired();
            builder.HasOne(q=>q.Hotel).WithMany(q=>q.Reservations).HasForeignKey(q=>q.Hotel).OnDelete(DeleteBehavior.Cascade);
            



        }
    }
}
