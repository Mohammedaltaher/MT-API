using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class DriverTypeConfiguration : IEntityTypeConfiguration<DriverType>
    {
        public void Configure(EntityTypeBuilder<DriverType> builder)
        {
            builder.ToTable("SettingsMotorDriverTypes");
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
                new DriverType { Id = 1, Name = "Primary Driver", NameAr = "سائق رئيسي" },
                new DriverType { Id = 2, Name = "Additional Driver", NameAr = "سائق إضافي" });
            #endregion
        }
    }
}
