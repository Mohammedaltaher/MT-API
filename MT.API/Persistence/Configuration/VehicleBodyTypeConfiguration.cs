using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleBodyTypeConfiguration : IEntityTypeConfiguration<VehicleBodyType>
    {
        public void Configure(EntityTypeBuilder<VehicleBodyType> builder)
        {
            builder.ToTable("SettingsVehicleBodyTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);
        }
    }
}
