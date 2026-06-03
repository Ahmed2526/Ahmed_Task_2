using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class InvoiceLineConfiguration : IEntityTypeConfiguration<InvoiceLine>
    {
        public void Configure(EntityTypeBuilder<InvoiceLine> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.ItemCode)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.Property(x => x.Description)
                   .IsRequired()
                   .HasMaxLength(1000);

            builder.Property(x => x.Quantity)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.UnitPrice)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.SalesTotal)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.DiscountPerUnit)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.DiscountPercentage)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.TotalTaxableFees)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.NetTotal)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.UnitType)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            builder.HasOne<Invoice>()
                   .WithMany(x => x.Lines)
                   .HasForeignKey(x => x.InvoiceId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
