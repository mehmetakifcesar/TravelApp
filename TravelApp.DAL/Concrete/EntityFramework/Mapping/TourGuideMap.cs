using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class TourGuideMap : BaseMap<TourGuide>
    {
        public virtual void Configure(EntityTypeBuilder<TourGuide> builder)
        {
            builder.ToTable("TourGuide");
            builder.Property(q => q.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(q => q.LastName).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(50).IsRequired();
            builder.Property(q => q.PhoneNumber).HasMaxLength(15).IsRequired();
            



        }
    }
}
