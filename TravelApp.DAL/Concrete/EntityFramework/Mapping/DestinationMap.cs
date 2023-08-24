using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class DestinationMap : BaseMap<Destination>
    {
        public virtual void Configure(EntityTypeBuilder<Destination> builder)
        {
            builder.ToTable("Destination");
            builder.Property(q => q.Name).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Description).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Country).HasMaxLength(50).IsRequired();
            builder.Property(q => q.City).HasMaxLength(50).IsRequired();
            
        }

    } 
}
