using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleColorConfiguration : IEntityTypeConfiguration<VehicleColor>
    {
        public void Configure(EntityTypeBuilder<VehicleColor> builder)
        {
            builder.ToTable("SettingsVehicleColor");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(50);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(50);

            #region Default Data
            builder.HasData(
                new TransmissionType { Id = 1, Name = "White", NameAr = "أبيض" },
                new TransmissionType { Id = 2, Name = "Black", NameAr = "أسود" },
                new TransmissionType { Id = 3, Name = "Blue", NameAr = "أزرق" },
                new TransmissionType { Id = 4, Name = "Red", NameAr = "أحمر" },
                new TransmissionType { Id = 5, Name = "Green", NameAr = "أخضر" },
                new TransmissionType { Id = 6, Name = "Yellow", NameAr = "أصفر" },
                new TransmissionType { Id = 7, Name = "Gold", NameAr = "ذهبي" },
                new TransmissionType { Id = 8, Name = "Silver", NameAr = "فضي" },
                new TransmissionType { Id = 9, Name = "Orange", NameAr = "برتقالي" },
                new TransmissionType { Id = 10, Name = "Pink", NameAr = "وردي" },
                new TransmissionType { Id = 11, Name = "Brown", NameAr = "بني" },
                new TransmissionType { Id = 12, Name = "Beige", NameAr = "بيج" },
                new TransmissionType { Id = 13, Name = "Gray", NameAr = "رمادي" },
                new TransmissionType { Id = 14, Name = "Light Blue", NameAr = "سماوي" },
                new TransmissionType { Id = 15, Name = "Dark Green", NameAr = "أخضر غامق" },
                new TransmissionType { Id = 16, Name = "Pearl", NameAr = "لولي" },
                new TransmissionType { Id = 17, Name = "Purple", NameAr = "بنفسجي" });
            #endregion
        }
    }
}
