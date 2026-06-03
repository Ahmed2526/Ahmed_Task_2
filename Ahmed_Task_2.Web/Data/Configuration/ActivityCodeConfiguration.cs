using Ahmed_Task_2.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ahmed_Task_2.Web.Data.Configuration
{
    public class ActivityCodeConfiguration : IEntityTypeConfiguration<ActivityCode>
    {
        public void Configure(EntityTypeBuilder<ActivityCode> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(500)
                   .IsRequired();

            builder.HasData(
                 new ActivityCode { Id = 111, Name = "Cultivation of grains and crops (except for rice), legumes and oilseeds" },
                 new ActivityCode { Id = 112, Name = "Cultivation of rice" },
                 new ActivityCode { Id = 113, Name = "Cultivation of vegetables, melons, roots and tubers" },
                 new ActivityCode { Id = 114, Name = "Cultivation of sugar cane" },
                 new ActivityCode { Id = 115, Name = "Tobacco cultivation" },
                 new ActivityCode { Id = 116, Name = "Growing fibre crops" },
                 new ActivityCode { Id = 119, Name = "Cultivation of other non-perennial crops" },
                 new ActivityCode { Id = 121, Name = "The cultivation of grapefruit" },
                 new ActivityCode { Id = 122, Name = "Growing tropical and subtropical fruits" },
                 new ActivityCode { Id = 123, Name = "Cultivation of citrus fruits" },
                 new ActivityCode { Id = 124, Name = "Cultivation of fruit with stone kernel and from palm trees" },
                 new ActivityCode { Id = 125, Name = "Plant fruit trees and shrubs and other nuts" },
                 new ActivityCode { Id = 127, Name = "Growing of tea" },
                 new ActivityCode { Id = 128, Name = "Cultivation of spices crops, aromatic, medicinal and pharmaceutical drugs" },
                 new ActivityCode { Id = 129, Name = "Cultivation of other perennial crops" },
                 new ActivityCode { Id = 130, Name = "Propagation" },
                 new ActivityCode { Id = 141, Name = "Breeding of cattle and buffalo" },
                 new ActivityCode { Id = 142, Name = "Breeding of horses and mare" },
                 new ActivityCode { Id = 143, Name = "Breeding of camels" },
                 new ActivityCode { Id = 144, Name = "Breeding sheep and goat" },
                 new ActivityCode { Id = 145, Name = "Breeding of pig" },
                 new ActivityCode { Id = 146, Name = "Poultry farming" },
                 new ActivityCode { Id = 149, Name = "Breeding other animals" },
                 new ActivityCode { Id = 150, Name = "Mixed agricultural and animal production" },
                 new ActivityCode { Id = 161, Name = "Support activities for animal production" },
                 new ActivityCode { Id = 162, Name = "Activities in support of animal production" },
                 new ActivityCode { Id = 163, Name = "Post-harvest activities" },
                 new ActivityCode { Id = 164, Name = "Preparing grains for production" });

        }
    }
}
