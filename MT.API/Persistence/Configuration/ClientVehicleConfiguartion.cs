using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ClientVehicleConfiguartion : IEntityTypeConfiguration<ClientVehicle>
    {
        public void Configure(EntityTypeBuilder<ClientVehicle> builder)
        {
            builder.ToTable("ClientsVehicles");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.VehicleIdTypeId)
                   .IsRequired();

            builder.Property(p => p.VehiclePlateNumber)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(p => p.VehiclePlateFirstLetterId).IsRequired();
            builder.Property(p => p.VehiclePlateSecondLetterId).IsRequired();
            builder.Property(p => p.VehiclePlateThirdLetterId).IsRequired();
            builder.Property(p => p.VehicleChassisNumber)
                   .HasMaxLength(50)
                   .IsRequired();
            builder.Property(p => p.VehicleOwnerName).HasMaxLength(150);
            builder.Property(p => p.VehicleRegistrationExpiryDate).HasMaxLength(25);
            builder.Property(p => p.VehicleModificationDetails).HasMaxLength(500);
            builder.HasOne(p => p.Client).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehicleIdType).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleIdTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehiclePlateFirstLetter).WithMany(p => p.ClientVehicleFrLetters).HasForeignKey(p => p.VehiclePlateFirstLetterId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehiclePlateSecondLetter).WithMany(p => p.ClientVehicleScLetters).HasForeignKey(p => p.VehiclePlateSecondLetterId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehiclePlateThirsdLetter).WithMany(p => p.ClientVehicleThLetters).HasForeignKey(p => p.VehiclePlateThirdLetterId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehiclePlateType).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehiclePlateTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehicleMaker).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleMakerId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehicleModel).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleModelId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehicleMajorColor).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleMajorColorId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleBodyType).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleBodyTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleRegistrationCity).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleRegistrationCityId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleRepairMethod).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleRepairMethodId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleUse).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleUseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleTransmissionType).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleTransmissionTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleAxleWeight).WithMany(p => p.ClientVehicles).HasForeignKey(p => p.VehicleAxleWeightId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);



            




        }
    }
}
