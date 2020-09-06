using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class MedicalConditionConfigutation : IEntityTypeConfiguration<MedicalCondition>
    {
        public void Configure(EntityTypeBuilder<MedicalCondition> builder)
        {
            builder.ToTable("SettingsMedicalConditions");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);



            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new MedicalCondition { Id = 1, Name = "No Restriction", NameAr = "بدون قيود" },
                new MedicalCondition { Id = 2, Name = "Automatic Car", NameAr = "سيارة أوتوماتيك" },
                new MedicalCondition { Id = 3, Name = "Prosthetic Limb", NameAr = "طرف صناعي" },
                new MedicalCondition { Id = 4, Name = "Vision Augmenting Lenses", NameAr = "عدسات مقوية للنظر" },
                new MedicalCondition { Id = 5, Name = "Only Day Time", NameAr = "لساعات النهار فقط" },
                new MedicalCondition { Id = 6, Name = "Hearing Aid", NameAr = "سماعة الأذن" },
                new MedicalCondition { Id = 7, Name = "Driving Inside KSA Only", NameAr = "القيادة داخل المملكة فقط" },
                new MedicalCondition { Id = 8, Name = "Handicap Car", NameAr = "سيارة خاصة لذوي الإحتياجات الخاصة" },
                new MedicalCondition { Id = 9, Name = "For Private Use With No Payment", NameAr = "الإستخدام الخاص وبدون أجر" });

            #endregion
        }
    }
}
