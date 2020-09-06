using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class DrivingPercentageConfiguration : IEntityTypeConfiguration<DrivingPercentage>
    {
        public void Configure(EntityTypeBuilder<DrivingPercentage> builder)
        {
            builder.ToTable("SettingsMotorDrivingPercentages");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(50);



            builder.Property(p => p.NameAr)
                   .HasMaxLength(50);



            #region Default Data
            builder.HasData(
                new DrivingPercentage { Id = 25, Name = "25%", NameAr = "25%" },
                new DrivingPercentage { Id = 50, Name = "50%", NameAr = "50%" },
                new DrivingPercentage { Id = 75, Name = "75%", NameAr = "75%" },
                new DrivingPercentage { Id = 100, Name = "100%", NameAr = "100%" });
            #endregion
        }
    }
}
