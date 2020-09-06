using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehiclePlateTypeConfiguration : IEntityTypeConfiguration<VehiclePlateType>
    {
        public void Configure(EntityTypeBuilder<VehiclePlateType> builder)
        {
            builder.ToTable("SettingsVehiclePlateTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(150);



            builder.Property(p => p.NameAr)
                   .HasMaxLength(150);



            #region Default Data
            builder.HasData(
                new VehicleIdType { Id = 1, Name = "Private Car", NameAr = "خصوصي" },
                new VehicleIdType { Id = 2, Name = "Public Transport", NameAr = "نقل عام" },
                new VehicleIdType { Id = 3, Name = "Private Transport", NameAr = "نقل خاص" },
                new VehicleIdType { Id = 4, Name = "Public Bus", NameAr = "حافلة صغيرة عامة" },
                new VehicleIdType { Id = 5, Name = "Private Bus", NameAr = "حافلة صغيرة خاصة" },
                new VehicleIdType { Id = 6, Name = "Taxi", NameAr = "اجرة" },
                new VehicleIdType { Id = 7, Name = "Heavy Equipment", NameAr = "معدات ثقيلة" },
                new VehicleIdType { Id = 8, Name = "Export", NameAr = "تصدير" },
                new VehicleIdType { Id = 9, Name = "Diplomatic", NameAr = "دبلوماسي" },
                new VehicleIdType { Id = 10, Name = "Motorcycle", NameAr = "دراجة نارية" },
                new VehicleIdType { Id = 11, Name = "Temporary", NameAr = "مؤقت" });
            #endregion
        }
    }
}
