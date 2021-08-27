using FarolCashBox.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FarolCashBox.Infra.Maps
{
    public class CashBoxMap : IEntityTypeConfiguration<CashBox>
    {
        public void Configure(EntityTypeBuilder<CashBox> builder)
        {
            builder.ToTable("CashBox");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.TotalAmount)
                .IsRequired();

            builder.HasMany(c => c.Orders)
            .WithOne(c => c.CashBox)
            .HasForeignKey(c => c.CashBoxId)
            .IsRequired(true);
        }
    }
}
