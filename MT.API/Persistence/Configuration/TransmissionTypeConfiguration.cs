using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class TransmissionTypeConfiguration : IEntityTypeConfiguration<TransmissionType>
    {
        public void Configure(EntityTypeBuilder<TransmissionType> builder)
        {
            builder.ToTable("SettingsMotorTransmissionTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(150);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(150);

            #region Default Data
            builder.HasData(
                new TransmissionType { Id = 1, Name = "Manual", NameAr = "يدوي" },
                new TransmissionType { Id = 2, Name = "Automatic", NameAr = "أوتوماتيك" });
            #endregion
        }
    }
}
