using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class RegionConfiguartion : IEntityTypeConfiguration<Region>
    {
        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.ToTable("SettingsRegions");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);
            builder.HasMany(p => p.Cities).WithOne(p => p.Region).HasForeignKey(p => p.RegionId).OnDelete(DeleteBehavior.NoAction);

            #region Default Data
            builder.HasData(
                new Region { Id = 1, Name = "Riyadh", NameAr = "الرياض" },
                new Region { Id = 2, Name = "Makkah", NameAr = "مكة المكرمة" },
                new Region { Id = 3, Name = "Madinah", NameAr = "المدينة المنورة" },
                new Region { Id = 4, Name = "Qassim", NameAr = "القصيم" },
                new Region { Id = 5, Name = "Eastern Province", NameAr = "الشرقية" },
                new Region { Id = 6, Name = "Asir", NameAr = "عسير" },
                new Region { Id = 7, Name = "Tabuk", NameAr = "تبوك" },
                new Region { Id = 8, Name = "Hail", NameAr = "حائل" },
                new Region { Id = 9, Name = "Northern Borders", NameAr = "الحدود الشمالية" },
                new Region { Id = 10, Name = "Jizan", NameAr = "جازان" },
                new Region { Id = 11, Name = "Najran", NameAr = "نجران" },
                new Region { Id = 12, Name = "Bahah", NameAr = "الباحة" },
                new Region { Id = 13, Name = "Jawf", NameAr = "الجوف" });
            #endregion
        }
    }
}
