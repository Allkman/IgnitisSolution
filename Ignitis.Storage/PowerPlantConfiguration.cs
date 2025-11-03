using Ignitis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ignitis.Storage
{
    public class PowerPlantConfiguration : IEntityTypeConfiguration<PowerPlant>
    {
        public void Configure(EntityTypeBuilder<PowerPlant> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(pp => pp.Owner)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(pp => pp.Power).HasPrecision(18,1).IsRequired();
            builder.Property(pp => pp.ValidFrom).IsRequired();
        }
    }
}
