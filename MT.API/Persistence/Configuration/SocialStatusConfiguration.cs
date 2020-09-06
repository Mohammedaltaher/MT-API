using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class SocialStatusConfiguration : IEntityTypeConfiguration<SocialStatus>
    {
        public void Configure(EntityTypeBuilder<SocialStatus> builder)
        {
            builder.ToTable("SettingsSocialStatus");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(500);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(500);

            #region Default Data
            builder.HasData(
                new SocialStatus { Id = 1, Name = "Single", NameAr = "أعزب" },
                new SocialStatus { Id = 2, Name = "Married", NameAr = "متزوج" },
                new SocialStatus { Id = 3, Name = "Divorced", NameAr = "مطلقة" },
                new SocialStatus { Id = 4, Name = "Widowed", NameAr = "أرملة" });
            #endregion
        }
    }
}
