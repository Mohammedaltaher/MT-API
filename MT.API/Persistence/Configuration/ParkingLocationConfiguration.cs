using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ParkingLocationConfiguration : IEntityTypeConfiguration<ParkingLocation>
    {
        public void Configure(EntityTypeBuilder<ParkingLocation> builder)
        {
            builder.ToTable("SettingsParkingLocations");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(150);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(150);

            #region Default Data
            builder.HasData(
                new ParkingLocation { Id = 1, Name = "Road-Side", NameAr = "الشارع" },
                new ParkingLocation { Id = 2, Name = "Drive-Way", NameAr = "الممر المؤدي إلى المنزل" },
                new ParkingLocation { Id = 3, Name = "Garaged", NameAr = "المرآب" });
            #endregion
        }
    }
}
