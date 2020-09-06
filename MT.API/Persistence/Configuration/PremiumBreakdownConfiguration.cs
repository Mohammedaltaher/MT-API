using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class PremiumBreakdownConfiguration : IEntityTypeConfiguration<PremiumBreakdown>
    {
        public void Configure(EntityTypeBuilder<PremiumBreakdown> builder)
        {
            builder.ToTable("SettingsMotorPremiumBreakdowns");
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
                new PremiumBreakdown { Id = 1, Name = "Basic Premium", NameAr = "القسط الاساسي" },
                new PremiumBreakdown { Id = 2, Name = "Additional Age Contribution", NameAr = "العمر الإضافي" },
                new PremiumBreakdown { Id = 3, Name = "Admin Fees", NameAr = "المصاريف الادارية" },
                new PremiumBreakdown { Id = 4, Name = "Additional loading (Due to accidents)", NameAr = "تحميل إضافي (بسبب الحوادث)" },
                new PremiumBreakdown { Id = 5, Name = "Value Added Tax (VAT)", NameAr="ضريبة القيمة المضافة" }
                );
            #endregion
        }
    }
}
