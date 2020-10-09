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
    public class FunctionalityAppRoleConfiguration : IEntityTypeConfiguration<FunctionalityAppRole>
    {
        public FunctionalityAppRoleConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<FunctionalityAppRole> builder)
        {
            builder.HasOne(x => x.AppRole)
                .WithMany(x => x.FunctionalityAppRoles)
                .HasForeignKey(x => x.AppRoleId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
            
            builder.HasOne(x => x.Functionality)
                .WithMany(x => x.FunctionalityAppRoles)
                .HasForeignKey(x => x.FunctionalityId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();
        }
    }
}
