using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class QuotationRequestConfiguartion : IEntityTypeConfiguration<QuotationsMotorRequest>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorRequest> builder)
        {
            builder.ToTable("QuotationsMotorRequests");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.RequestReferenceId)
                   .HasMaxLength(50)
                   .IsRequired().HasDefaultValueSql("dbo.GenerateQuotationRequestId()");
            builder.Property(p => p.PolicyEffectiveDate)
                   .HasColumnType("datetime")
                   .IsRequired();
            builder.Property(p => p.PromoCode)
                   .HasMaxLength(50);
            builder.Property(p => p.InsuredBirthDate)
                   .HasMaxLength(50);
            builder.Property(p => p.VehicleChassisNumber)
                  .HasMaxLength(150);
            builder.Property(p => p.VehicleSpecifications)
                  .HasMaxLength(500);
            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(450);
                  
            builder.Property(p => p.InsuredFirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.InsuredMiddleName).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.InsuredLastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.InsuredFirstNameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.InsuredMiddleNameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.InsuredLastNameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.VehiclePlateNumber).HasMaxLength(50).IsRequired();
            
            builder.Property(p => p.InsuredCity).HasMaxLength(250).IsRequired(false);
            builder.Property(p => p.InsuredStreet).HasMaxLength(50).IsRequired(false);


            builder.HasOne(p => p.IdentityType).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.InsuredIdentityTypeId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Gender).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.InsuredGenderId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.InsuredIdentityNumber).IsRequired();

            builder.HasOne(p => p.IdentityIssuePlace).WithMany(p => p.QuotationRequestsIdentityIssuePlace).HasForeignKey(p => p.InsuredIdentityIssuePlaceId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(p => p.Nationality).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.InsuredNationalityId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.SocialStatus).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.InsuredSocialStatusId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.EducationLevel).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.InsuredEducationLevelId)
                .OnDelete(DeleteBehavior.NoAction);
            

            builder.Property(p => p.VehiclePlateFirstLetterId).IsRequired();
            builder.Property(p => p.VehiclePlateSecondLetterId).IsRequired();
            builder.Property(p => p.VehiclePlateThirdLetterId).IsRequired();
            builder.Property(p => p.VehicleOwnerName).HasMaxLength(150);
            builder.Property(p => p.VehicleRegistrationExpiryDate).HasMaxLength(25);
            builder.Property(p => p.VehicleModificationDetails).HasMaxLength(500);

            builder.Property(p => p.VehicleSumInsured).HasColumnType("decimal(18,2)").IsRequired();

            builder.HasOne(p => p.Client).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.ApplicationUser).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.CreatedBy).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleIdType).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleIdTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehiclePlateFirstLetter).WithMany(p => p.QuotationRequestFrLetters).HasForeignKey(p => p.VehiclePlateFirstLetterId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehiclePlateSecondLetter).WithMany(p => p.QuotationRequestScLetters).HasForeignKey(p => p.VehiclePlateSecondLetterId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehiclePlateThirsdLetter).WithMany(p => p.QuotationRequestThLetters).HasForeignKey(p => p.VehiclePlateThirdLetterId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.VehiclePlateType).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehiclePlateTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleMaker).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleMakerId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleModel).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleModelId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleMajorColor).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleMajorColorId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleBodyType).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleBodyTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleRegistrationCity).WithMany(p => p.QuotationRequestsVehicleReqCity).HasForeignKey(p => p.VehicleRegistrationCityId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleRepairMethod).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleRepairMethodId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleUse).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleUseId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleTransmissionType).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleTransmissionTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.VehicleAxleWeight).WithMany(p => p.QuotationsMotorRequests).HasForeignKey(p => p.VehicleAxleWeightId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.WorkCity).WithMany(p => p.QuotationRequestsWorkCity).HasForeignKey(p => p.InsuredWorkCityId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.DrivingCity).WithMany(p => p.QuotationRequestsDrivingCity).HasForeignKey(p => p.DrivingCityId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);



            




        }
    }
}
