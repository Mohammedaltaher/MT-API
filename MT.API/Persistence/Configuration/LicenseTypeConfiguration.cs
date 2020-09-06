using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class LicenseTypeConfiguration : IEntityTypeConfiguration<LicenseType>
    {
        public void Configure(EntityTypeBuilder<LicenseType> builder)
        {
            builder.ToTable("SettingsMotorLicenseTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new LicenseType { Id = 1, Name = "Temporary License (Permission)", NameAr = "رخصة مؤقتة (صريح)" },
                new LicenseType { Id = 2, Name = "Motorcycle", NameAr = "دراجة نارية" },
                new LicenseType { Id = 3, Name = "Private", NameAr = "خاصة" },
                new LicenseType { Id = 4, Name = "Public Taxi", NameAr = "اجرة عامة" },
                new LicenseType { Id = 5, Name = "Pickup / Passing Cars", NameAr = "نقل صغير / سيارات عابرة" },
                new LicenseType { Id = 6, Name = "Light Transport", NameAr = "نقل خفيف" },
                new LicenseType { Id = 7, Name = "Heavy Transport", NameAr = "نقل ثقيل" },
                new LicenseType { Id = 8, Name = "Public Works Vehicles", NameAr = "مركبات اشغال عامة" },
                new LicenseType { Id = 9, Name = "Small Bus", NameAr = "حافلة صغيرة" },
                new LicenseType { Id = 10, Name = "Large Bus", NameAr = "حافلة كبيرة" },
                new LicenseType { Id = 11, Name = "Public Private", NameAr = "عمومي خاصة" });
            #endregion
        }
    }
}
