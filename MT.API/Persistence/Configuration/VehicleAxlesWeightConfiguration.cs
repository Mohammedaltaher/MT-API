using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleAxlesWeightConfiguration : IEntityTypeConfiguration<VehicleAxlesWeight>
    {
        public void Configure(EntityTypeBuilder<VehicleAxlesWeight> builder)
        {
            builder.ToTable("SettingsVehicleAxlesWeights");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(150);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(150);

            #region Default Data
            builder.HasData(
                new VehicleAxlesWeight { Id = 1, Name = "Up Tp 20 Tons", NameAr = "حتى 20 طن" },
                new VehicleAxlesWeight { Id = 2, Name = "20 - 30 Tons", NameAr = "طن 30 - 20 من" },
                new VehicleAxlesWeight { Id = 3, Name = "30 - 40 Tons", NameAr = "طن 40 - 30 من" },
                new VehicleAxlesWeight { Id = 4, Name = "Above 40 Tons", NameAr = "أكثر من 40 طن" });
            #endregion
        }
    }
}
