using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class ReservationDetailMap : BaseMap<ReservationDetail>
    {
        public virtual void Configure(EntityTypeBuilder<ReservationDetail> builder)
        {
            builder.ToTable("ReservationDetail");
            builder.Property(q=>q.ReservationID).IsRequired();
            builder.Property(q=>q.DateTime).IsRequired();
            builder.HasOne(q=>q.Reservation).WithMany(q=>q.ReservationDetails).HasForeignKey(q=>q.ReservationID)
                .OnDelete(DeleteBehavior.Cascade);





        }
    }
}
