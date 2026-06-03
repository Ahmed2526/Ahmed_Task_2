using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class InvoiceTaxConfiguration : IEntityTypeConfiguration<InvoiceTax>
    {
        public void Configure(EntityTypeBuilder<InvoiceTax> builder)
        {
            builder.Property(x => x.Rate)
                .HasPrecision(18, 5).IsRequired();

            builder.Property(x => x.Amount)
                .HasPrecision(18, 5).IsRequired(); 

            builder.HasOne(x => x.InvoiceLine)
                .WithMany(x => x.Taxes)
                .HasForeignKey(x => x.InvoiceLineId)
                .OnDelete(DeleteBehavior.Cascade); 

            builder.HasOne(x => x.TaxType)
                .WithMany()
                .HasForeignKey(x => x.TaxTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.TaxSubType)
                .WithMany()
                .HasForeignKey(x => x.TaxSubTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasIndex(x => x.InvoiceLineId);
            builder.HasIndex(x => x.TaxTypeId);
            builder.HasIndex(x => x.TaxSubTypeId);
        }
    }
}
