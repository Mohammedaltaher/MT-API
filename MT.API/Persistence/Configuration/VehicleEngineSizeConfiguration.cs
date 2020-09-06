using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleEngineSizeConfiguration : IEntityTypeConfiguration<VehicleEngineSize>
    {
        public void Configure(EntityTypeBuilder<VehicleEngineSize> builder)
        {
            builder.ToTable("SettingsVehicleEngineSizes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new VehicleEngineSize { Id = 1, Name = "Up To 2,000 CC", NameAr = "حتى ى مكعب) 2,000 (سنتمت " },
                new VehicleEngineSize { Id = 2, Name = "2000 CC to 4,000 CC", NameAr = "من  ى مكعب) 4,000 إلى 2,000 (سنتمت" },
                new VehicleEngineSize { Id = 3, Name = "Above 4,000 CC", NameAr = "فوق  ى مكعب) 4,000 (سنتمت" });
                
            #endregion
        }
    }
}
