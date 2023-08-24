using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class HotelMap : BaseMap<Hotel>
    {
        public virtual void Configure(EntityTypeBuilder<Hotel> builder)
        {
            builder.ToTable("Hotel");
            builder.Property(q => q.Name).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Adress).HasMaxLength(300).IsRequired();
            builder.Property(q => q.RoomNumber).HasMaxLength(300).IsRequired();
            builder.Property(q => q.Country).HasMaxLength(50).IsRequired();
            builder.Property(q => q.City).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Price).HasMaxLength(50).IsRequired();
            
            




        }
    }
}
