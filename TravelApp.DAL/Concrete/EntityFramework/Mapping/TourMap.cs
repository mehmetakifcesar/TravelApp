using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class TourMap : BaseMap<Tour>
    {
        public virtual void Configure(EntityTypeBuilder<Tour> builder)
        {
            builder.ToTable("Tour");
            builder.Property(q => q.Name).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Description).HasMaxLength(500).IsRequired();
            builder.Property(q => q.Destinations).HasMaxLength(50).IsRequired();
            builder.Property(q => q.StartingDate).HasMaxLength(50).IsRequired();
            builder.Property(q => q.EndingDate).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Price).HasMaxLength(6).IsRequired();
            builder.HasOne(q=>q.TourCompany).WithMany(q=>q.Tours).HasForeignKey(q=>q.Destinations).OnDelete(DeleteBehavior.Cascade);
            //builder.HasIndex(q => q.Name).HasDatabaseName("INX_TOUR_NAME");


        }
    }
}
