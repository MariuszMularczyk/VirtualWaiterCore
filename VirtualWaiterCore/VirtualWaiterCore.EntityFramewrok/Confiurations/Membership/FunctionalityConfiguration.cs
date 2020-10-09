using VirtualWaiterCore.Domain;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VirtualWaiterCore.EntityFramework
{
    public class FunctionalityConfiguration : IEntityTypeConfiguration<Functionality>
    {
        public FunctionalityConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<Functionality> builder)
        {
            builder.HasMany(x => x.FunctionalityAppRoles)
                .WithOne(x => x.Functionality)
                .HasForeignKey(x => x.FunctionalityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
