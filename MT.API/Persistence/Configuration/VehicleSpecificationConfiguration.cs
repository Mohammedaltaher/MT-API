using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleSpecificationConfiguration : IEntityTypeConfiguration<VehicleSpecification>
    {
        public void Configure(EntityTypeBuilder<VehicleSpecification> builder)
        {
            builder.ToTable("SettingsVehicleSpecifications");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new VehicleSpecification { Id = 1, Name = "Anti-Theft Alarm", NameAr = "جهاز إنذار ضد السرقة" },
                new VehicleSpecification { Id = 2, Name = "Fire Extinguisher", NameAr = "طفاية الحريق" },
                new VehicleSpecification { Id = 3, Name = "Anti-Lock Brake System", NameAr = "نظام مكابح مانع لإلنزالق" },
                new VehicleSpecification { Id = 4, Name = "Auto Braking System", NameAr = "نظام مكابح أتوماتيكي ( لمنع من وقوع االصطدام الوشيك او الحد من آثاره )" },
                new VehicleSpecification { Id = 5, Name = "Cruise Control", NameAr = "مثبت السرعة" },
                new VehicleSpecification { Id = 6, Name = "Adaptive Cruise Control", NameAr = "مثبت السرعة التكيفي" },
                new VehicleSpecification { Id = 7, Name = "Rear Sensors", NameAr = "حساسات خلفية" },
                new VehicleSpecification { Id = 8, Name = "Front Sensors", NameAr = "حساسات أمامية" },
                new VehicleSpecification { Id = 9, Name = "Rear Camera", NameAr = "كاميرا خلفية" },
                new VehicleSpecification { Id = 10, Name = "Front Camera", NameAr = "كاميرا أمامية" },
                new VehicleSpecification { Id = 11, Name = "360 Camera", NameAr = "كاميرا ذات 360 درجة" });
            #endregion
        }
    }
}
