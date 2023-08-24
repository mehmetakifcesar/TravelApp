using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelApp.Entity.Base;

namespace TravelApp.DAL.Concrete.EntityFramework.Mapping.BaseMap
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : AuditableEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(q => q.ID);
            builder.Property(q=> q.ID).ValueGeneratedOnAdd();
            builder.Property(q=>q.GUID).ValueGeneratedOnAdd();
        }
    }
}
