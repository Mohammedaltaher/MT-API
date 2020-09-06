using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleRepairMethodConfiguartion : IEntityTypeConfiguration<VehicleRepairMethod>
    {
        public void Configure(EntityTypeBuilder<VehicleRepairMethod> builder)
        {
            builder.ToTable("SettingsVehicleRepairMethods");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new VehicleIdType { Id = 1, Name = "Agency", NameAr = "وكالة" },
                new VehicleIdType { Id = 2, Name = "workshop", NameAr = "ورشات صيانة" });
            #endregion
        }
    }
}
