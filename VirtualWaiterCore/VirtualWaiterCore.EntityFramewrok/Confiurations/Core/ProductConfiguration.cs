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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasMany(x => x.ProductOrders)
                .WithOne(x => x.Product)
                .IsRequired()
                .HasForeignKey(x => x.ProductId);
        }
    }
}
