using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleMakerConfiguration : IEntityTypeConfiguration<VehicleMaker>
    {
        public void Configure(EntityTypeBuilder<VehicleMaker> builder)
        {
            builder.ToTable("SettingsVehicleMakers");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);


            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            builder.HasMany(x => x.VehicleModels)
                   .WithOne(x => x.VehicleMaker)
                   .HasForeignKey(x => x.VehicleMakerId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
