using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class TourCompanyMap : BaseMap<TourCompany>
    {
        public virtual void Configure(EntityTypeBuilder<TourCompany> builder)
        {
            builder.ToTable("TourCompany");
            builder.Property(q => q.Name).HasMaxLength(50).IsRequired();
            builder.Property(q=>q.Adress).HasMaxLength(300).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(50).IsRequired();
            builder.Property(q => q.PhoneNumber).HasMaxLength(15).IsRequired();
            




        }
    }
}
