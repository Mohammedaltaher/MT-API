using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class DiscountTypeConfiguration : IEntityTypeConfiguration<DiscountType>
    {
        public void Configure(EntityTypeBuilder<DiscountType> builder)
        {
            builder.ToTable("SettingsMotorDiscountTypes");
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
                new DiscountType { Id = 1, Name = "Special Discount", NameAr = "خصم خاص" },
                new DiscountType { Id = 2, Name = "No Claim Discount", NameAr = "خصم عدم وجود مطالبات" },
                new DiscountType { Id = 3, Name = "Loyalty Discount", NameAr = "خصم الولاء" }
                //new PriceType { Id = 4, Name = "Additional loading (Due to accidents)", NameAr = "تحميل إضافي (بسبب الحوادث)" },
                //new PriceType { Id = 5, Name = "Additional Age Contribution", NameAr = "العمر الإضافي" },
                //new PriceType { Id = 6, Name = "Admin Fees", NameAr = "المصاريف الادارية" },
                //new PriceType { Id = 7, Name = "Basic Premium", NameAr = "القسط الاساسي" },
                //new PriceType { Id = 8, Name = "Value Added Tax (VAT)", NameAr = "ضريبة القيمة المضافة" });
                );
            #endregion
        }
    }
}
