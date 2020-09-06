using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    /// <summary>
    /// Product Type Fluent API Config.
    /// </summary>
    public class BenefitConfiguration : IEntityTypeConfiguration<Benefit>
    {
        public void Configure(EntityTypeBuilder<Benefit> builder)
        {
            builder.ToTable("SettingsMotorBenefits");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250)
                   .IsRequired();

            #region Default Data
            builder.HasData(
                new Benefit { Id = 1, Name = "Personal Accident coverage for the driver only", NameAr = "تغطية الحوادث الشخصية للسائق فقط" },
                new Benefit { Id = 2, Name = "Personal Accident coverage for the passenger only", NameAr = "تغطية الحوادث الشخصية للركاب" },
                new Benefit { Id = 3, Name = "Personal Accident coverage for the driver & passenger ", NameAr = "تغطية الحوادث الشخصية للسائق والركاب" },
                new Benefit { Id = 4, Name = "Natural Disasters", NameAr = "الكوارث الطبيعية" },
                new Benefit { Id = 5, Name = "Windscreen, fires & theft", NameAr = "الزجاج الأمامي والحرائق والسرقة" },
                new Benefit { Id = 6, Name = "Roadside Assistance", NameAr = "المساعدة على الطريق" },
                new Benefit { Id = 7, Name = "Hire Car", NameAr = "سيارة بديلة" },
                new Benefit { Id = 8, Name = "Agency Repairs", NameAr = "أصلاح وكالة" },
                new Benefit { Id = 9, Name = "Geographical coverage of GCC countries / Jordan / Egypt for 12 months", NameAr = "التغطية الجغرافية لدول مجلس التعاون الخليجي/ الاردن/مصر لمدة 12 شهر" }
                );
            #endregion

        }
    }
}
