using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class TaxTypeConfiguration : IEntityTypeConfiguration<TaxType>
    {
        public void Configure(EntityTypeBuilder<TaxType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasData(
                new TaxType
                {
                    Id = 1,
                    Name = "T1 - Value added tax"
                },
                new TaxType
                {
                    Id = 2,
                    Name = "T2 - Table tax (percentage)"
                },
                new TaxType
                {
                    Id = 3,
                    Name = "T3 - Table tax (fixed amount)"
                },
                new TaxType
                {
                    Id = 4,
                    Name = "T4 - Withholding tax (WHT)"
                },
                new TaxType
                {
                    Id = 5,
                    Name = "T5 - Stamping tax (percentage)"
                },
                new TaxType
                {
                    Id = 6,
                    Name = "T6 - Stamping tax (amount)"
                },
                new TaxType
                {
                    Id = 7,
                    Name = "T7 - Entertainment tax"
                },
                new TaxType
                {
                    Id = 8,
                    Name = "T8 - Resource development fee"
                },
                new TaxType
                {
                    Id = 9,
                    Name = "T9 - Table tax (percentage)"
                },
                new TaxType
                {
                    Id = 10,
                    Name = "T10 - Municipality fees"
                },
                new TaxType
                {
                    Id = 11,
                    Name = "T11 - Medical insurance fee"
                },
                new TaxType
                {
                    Id = 12,
                    Name = "T12 - Other fees"
                }
            );
        }
    }

}

