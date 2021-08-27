using FarolCashBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarolCashBox.Infra.Maps
{
    public class OrderMap : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Order");

            builder.HasKey(o => o.Id);

            builder.Property(o => o.TotalOrder)
                .IsRequired();

            builder.Property(o => o.PaymentType)
                .IsRequired()
                .HasConversion<string>();

            builder.HasMany(p => p.Products).WithMany(o => o.Orders);
        }
    }
}
