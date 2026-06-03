using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class InvoicePartyConfiguration : IEntityTypeConfiguration<InvoiceParty>
    {
        public void Configure(EntityTypeBuilder<InvoiceParty> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Type)
                   .HasConversion<string>()
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.RegistrationId)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Name)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.Country)
                   .HasMaxLength(100)
                   .IsRequired();

            builder.Property(x => x.Governorate)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.RegionCity)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.Property(x => x.Street)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.Property(x => x.BuildingNumber)
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.BranchId)
                   .HasMaxLength(50);

            builder.HasIndex(x => x.RegistrationId);
        }
    }
}
