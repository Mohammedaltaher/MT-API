using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class OccupationMaleConfiguartion : IEntityTypeConfiguration<OccupationMale>
    {
        public void Configure(EntityTypeBuilder<OccupationMale> builder)
        {
            builder.ToTable("SettingsOccupationMales");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);
        }
    }
}
