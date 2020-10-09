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
    public class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public AppUserConfiguration()
        {
        }
        public void Configure(EntityTypeBuilder<AppUser> builder) { 
        }
    }
}
