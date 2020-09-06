using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class SettingsAttachmentConfiguration : IEntityTypeConfiguration<Attachment>
    {
        public void Configure(EntityTypeBuilder<Attachment> builder)
        {
            builder.ToTable("SettingsAttachments");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasMaxLength(2);

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.InsurClass)
                   .HasMaxLength(250);


            #region Default Data
            builder.HasData(
                new Attachment { Id = 1, Name = "Vehicle Front Photo", NameAr = "واجهة المركبة الامامية",InsurClass="Motor",IsActive=true },
                new Attachment { Id = 2, Name = "Vehicle Back Photo", NameAr = "واجهة المركبة الخلفية", InsurClass = "Motor", IsActive = true },
                new Attachment { Id = 3, Name = "Vehicle Right Side Photo", NameAr = "صورة المركبة من الجانب الأيمن", InsurClass = "Motor", IsActive = true },
                new Attachment { Id = 4, Name = "Vehicle Left Side Photo", NameAr = "صورة المركبة من الجانب الإيسر", InsurClass = "Motor", IsActive = true },
                new Attachment { Id = 5, Name = "Vehicle Chassis Photo", NameAr = "رقم شاص المركبة", InsurClass = "Motor", IsActive = true });
            #endregion
        }
    }
}
