using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class TaxSubTypeConfiguration : IEntityTypeConfiguration<TaxSubType>
    {
        public void Configure(EntityTypeBuilder<TaxSubType> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.HasOne(x => x.TaxType)
                   .WithMany()
                   .HasForeignKey(x => x.TaxTypeId);

            builder.HasData(

                // T1 - Value Added Tax
                new TaxSubType { Id = 1, TaxTypeId = 1, Name = "V001 - Standard VAT Rate" },
                new TaxSubType { Id = 2, TaxTypeId = 1, Name = "V002 - Zero Rated VAT" },
                new TaxSubType { Id = 3, TaxTypeId = 1, Name = "V003 - Exempt VAT" },

                // T2 - Table Tax Percentage
                new TaxSubType { Id = 4, TaxTypeId = 2, Name = "TP001 - Local Services" },
                new TaxSubType { Id = 5, TaxTypeId = 2, Name = "TP002 - Luxury Goods" },

                // T3 - Table Tax Fixed Amount
                new TaxSubType { Id = 6, TaxTypeId = 3, Name = "TF001 - Fixed Service Fee" },
                new TaxSubType { Id = 7, TaxTypeId = 3, Name = "TF002 - Fixed Product Fee" },

                // T4 - Withholding Tax
                new TaxSubType { Id = 8, TaxTypeId = 4, Name = "W001 - Contractors" },
                new TaxSubType { Id = 9, TaxTypeId = 4, Name = "W002 - Professional Services" },
                new TaxSubType { Id = 10, TaxTypeId = 4, Name = "W003 - Suppliers" },

                // T5 - Stamp Percentage
                new TaxSubType { Id = 11, TaxTypeId = 5, Name = "SP001 - Commercial Contracts" },

                // T6 - Stamp Fixed Amount
                new TaxSubType { Id = 12, TaxTypeId = 6, Name = "SF001 - Fixed Stamp Duty" },

                // T7 - Entertainment Tax
                new TaxSubType { Id = 13, TaxTypeId = 7, Name = "E001 - Cinema" },
                new TaxSubType { Id = 14, TaxTypeId = 7, Name = "E002 - Events" },

                // T8 - Resource Development Fee
                new TaxSubType { Id = 15, TaxTypeId = 8, Name = "R001 - Tourism" },
                new TaxSubType { Id = 16, TaxTypeId = 8, Name = "R002 - Government Services" },

                // T9 - Table Tax Percentage
                new TaxSubType { Id = 17, TaxTypeId = 9, Name = "TP003 - Imported Goods" },

                // T10 - Municipality Fees
                new TaxSubType { Id = 18, TaxTypeId = 10, Name = "M001 - Municipality Services" },

                // T11 - Medical Insurance Fee
                new TaxSubType { Id = 19, TaxTypeId = 11, Name = "MI001 - Medical Insurance Contribution" },

                // T12 - Other Fees
                new TaxSubType { Id = 20, TaxTypeId = 12, Name = "O001 - Administrative Fee" },
                new TaxSubType { Id = 21, TaxTypeId = 12, Name = "O002 - Processing Fee" }
            );
        }
    }
}

