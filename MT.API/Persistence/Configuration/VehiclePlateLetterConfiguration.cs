using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehiclePlateLetterConfiguration : IEntityTypeConfiguration<VehiclePlateLetter>
    {
        public void Configure(EntityTypeBuilder<VehiclePlateLetter> builder)
        {
            builder.ToTable("SettingsVehiclePlateLetters");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(5);



            builder.Property(p => p.NameAr)
                   .HasMaxLength(5);



            #region Default Data
            builder.HasData(
                new VehiclePlateLetter { Id = 1, Name = "A", NameAr = "أ" },
                new VehiclePlateLetter { Id = 2, Name = "B", NameAr = "ب" },
                new VehiclePlateLetter { Id = 3, Name = "J", NameAr = "ح" },
                new VehiclePlateLetter { Id = 4, Name = "D", NameAr = "د" },
                new VehiclePlateLetter { Id = 5, Name = "R", NameAr = "ر" },
                new VehiclePlateLetter { Id = 6, Name = "S", NameAr = "س" },
                new VehiclePlateLetter { Id = 7, Name = "X", NameAr = "ص" },
                new VehiclePlateLetter { Id = 8, Name = "T", NameAr = "ط" },
                new VehiclePlateLetter { Id = 9, Name = "E", NameAr = "ع" },
                new VehiclePlateLetter { Id = 10, Name = "G", NameAr = "ق" },
                new VehiclePlateLetter { Id = 11, Name = "K", NameAr = "ك" },
                new VehiclePlateLetter { Id = 12, Name = "L", NameAr = "ل" },
                new VehiclePlateLetter { Id = 13, Name = "Z", NameAr = "م" },
                new VehiclePlateLetter { Id = 14, Name = "N", NameAr = "ن" },
                new VehiclePlateLetter { Id = 15, Name = "H", NameAr = "ه" },
                new VehiclePlateLetter { Id = 16, Name = "U", NameAr = "و" },
                new VehiclePlateLetter { Id = 17, Name = "V", NameAr = "ي" });
            #endregion
        }
    }
}
