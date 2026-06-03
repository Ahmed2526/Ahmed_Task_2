using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.InternalId)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.HasIndex(x => x.InternalId)
                   .IsUnique();

            builder.Property(x => x.DateIssued)
                   .IsRequired();

            builder.Property(x => x.NetAmount)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.Property(x => x.TotalAmount)
                   .HasPrecision(18, 5)
                   .IsRequired();

            builder.HasOne(x => x.ActivityCode)
                   .WithMany()
                   .HasForeignKey(x => x.ActivityCodeId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Issuer)
                   .WithMany()
                   .HasForeignKey(x => x.IssuerId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Receiver)
                   .WithMany()
                   .HasForeignKey(x => x.ReceiverId)
                   .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

