using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap;
using TravelApp.Entity.POCO;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping
{
    public class UserMap: BaseMap<User>
    {
        public virtual void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Property(q=>q.Username).HasMaxLength(50).IsRequired();
            builder.Property(q=>q.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(q => q.LastName).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Password).HasMaxLength(50).IsRequired();
            builder.Property(q => q.Email).HasMaxLength(50).IsRequired();
            builder.Property(q => q.PhoneNumber).HasMaxLength(15).IsRequired();
        }
    }
}
