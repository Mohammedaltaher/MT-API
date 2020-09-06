using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ViolationConfiguration : IEntityTypeConfiguration<Violation>
    {
        public void Configure(EntityTypeBuilder<Violation> builder)
        {
            builder.ToTable("SettingsViolations");
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
                new Violation { Id = 1, Name = "Speed Ticket", NameAr = "تجاوز السرعة المحددة" },
                new Violation { Id = 2, Name = "Override Traffic Light", NameAr = "تجاوز الاشارة الحمراء" },
                new Violation { Id = 3, Name = "Driving Opposite Direction", NameAr = "القيادة عكس الاتجاه" },
                new Violation { Id = 4, Name = "Drifting", NameAr = "التفحيط" },
                new Violation { Id = 5, Name = "Parking Violation", NameAr = "مخالفة الوقوف الخاطئ" });
            #endregion
        }
    }
}
