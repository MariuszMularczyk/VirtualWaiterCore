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
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public AppRoleConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasMany(x => x.FunctionalityAppRoles)
                .WithOne(x => x.AppRole)
                .IsRequired()
                .HasForeignKey(x => x.AppRoleId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
