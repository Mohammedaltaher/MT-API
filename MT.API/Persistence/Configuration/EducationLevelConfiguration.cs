using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class EducationLevelConfiguration : IEntityTypeConfiguration<EducationLevel>
    {
        public void Configure(EntityTypeBuilder<EducationLevel> builder)
        {
            builder.ToTable("SettingsEducationLevels");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(100);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(100);

            #region Default Data
            builder.HasData(
                new EducationLevel { Id = 1, Name = "Primary", NameAr = "ابتدائي" },
                new EducationLevel { Id = 2, Name = "Secondary", NameAr = "ثانوي" },
                new EducationLevel { Id = 3, Name = "Academic", NameAr = "جامعي" },
                new EducationLevel { Id = 4, Name = "High Education", NameAr = "دراسات عليا" });
            #endregion
        }
    }
}
