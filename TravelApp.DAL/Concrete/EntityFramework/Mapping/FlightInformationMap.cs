using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class FlightInformationMap : BaseMap<FlightInformation>
    {
       public virtual void Configure(EntityTypeBuilder<FlightInformation> builder)
        {
            builder.ToTable("FlightInformation");
            builder.Property(q => q.Airline).IsRequired().HasMaxLength(50);
            builder.Property(q => q.DepartureDate).IsRequired().HasMaxLength(50);
            builder.Property(q => q.ArrivalDate).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Origin).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Destination).IsRequired().HasMaxLength(50);
            builder.Property(q => q.Price).IsRequired().HasMaxLength(50);
           
            
        }
    }
}
