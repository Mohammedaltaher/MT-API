using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleUseConfiguration : IEntityTypeConfiguration<VehicleUse>
    {
        public void Configure(EntityTypeBuilder<VehicleUse> builder)
        {
            builder.ToTable("SettingsVehicleUses");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new TransmissionType { Id = 1, Name = "Private", NameAr = "شخصي" },
                new TransmissionType { Id = 2, Name = "Commercial", NameAr = "تجاري" });
            #endregion
        }
    }
}
