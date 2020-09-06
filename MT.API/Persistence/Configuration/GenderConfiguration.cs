using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("SettingsGenders");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasMaxLength(2);

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250)
                   .IsRequired();


            #region Default Data
            builder.HasData(
                new Gender { Id = "M", Name = "Male", NameAr = "ذكر" },
                new Gender { Id = "F", Name = "Female", NameAr = "أنثي" });
            #endregion
        }
    }
}
