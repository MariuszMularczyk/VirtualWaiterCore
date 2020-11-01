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
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder
                .HasOne<Order>(x => x.Order)
                .WithMany(o => o.ProductOrders)
                .HasForeignKey(x => x.OrderId);


            builder
                .HasOne<Product>(x => x.Product)
                .WithMany(p => p.ProductOrders)
                .HasForeignKey(x => x.ProductId);
        }
    }
}
