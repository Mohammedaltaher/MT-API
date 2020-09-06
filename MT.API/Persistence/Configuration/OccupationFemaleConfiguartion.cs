using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class OccupationFemaleConfiguartion : IEntityTypeConfiguration<OccupationFemale>
    {
        public void Configure(EntityTypeBuilder<OccupationFemale> builder)
        {
            builder.ToTable("SettingsOccupationFemales");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);
        }
    }
}
