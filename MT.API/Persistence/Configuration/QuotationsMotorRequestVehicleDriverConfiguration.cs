using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class QuotationsMotorRequestVehicleDriverConfiguration : IEntityTypeConfiguration<QuotationsMotorRequestVehicleDriver>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorRequestVehicleDriver> builder)
        {
            builder.ToTable("QuotationMotorRequestsVehicleDrivers");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.BirthDate)
                   .HasMaxLength(250)
                   .IsRequired(false);

            builder.Property(p => p.GenderId)
                   .HasMaxLength(2)
                   .IsRequired(false);

            builder.Property(p => p.FirstName)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.MiddleName)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.LastName)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.FirstNameAr)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.MiddleNameAr)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.LastNameAr)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.MedicalConditions)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.DriverViolations)
                   .HasMaxLength(50)
                   .IsRequired(false);

            builder.Property(p => p.NCDReference)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.CreatedDate)
                   .HasColumnType("datetime");
            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.QuotationsMotorRequest).WithMany(p => p.QuotationsMotorRequestVehicleDrivers).HasForeignKey(p => p.QuotationRequestId).IsRequired();
            builder.HasOne(p => p.Gender).WithMany(p => p.QuotationsMotorRequestVehicleDrivers).HasForeignKey(p => p.GenderId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            builder.HasOne(p => p.EducationLevel).WithMany(p => p.QuotationsMotorRequestVehicleDrivers).HasForeignKey(p => p.EducationLevelId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            builder.HasOne(p => p.DrivingPercentage).WithMany(p => p.QuotationsMotorRequestVehicleDrivers).HasForeignKey(p => p.DrivingPercentageId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            builder.HasOne(p => p.NCDFreeYear).WithMany(p => p.QuotationsMotorRequestVehicleDrivers).HasForeignKey(p => p.NCDFreeYearsId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Relation).WithMany(p => p.QuotationsMotorRequestVehicleDrivers).HasForeignKey(p => p.RelationId).OnDelete(DeleteBehavior.Restrict);
        }

    }

    public class QuotationsMotorRequestVehicleDriverAccidentConfiguration : IEntityTypeConfiguration<QuotationsMotorRequestVehicleDriverAccident>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorRequestVehicleDriverAccident> builder)
        {
            builder.ToTable("QuotationMotorRequestsVehicleDriverAccidents");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.CaseNumber)
                   .HasMaxLength(250)
                   .IsRequired(false);

            builder.Property(p => p.AccidentDate)
                   .HasColumnType("datetime")
                   .IsRequired(false);

            builder.Property(p => p.Liability)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.CityName)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.DriverAge)
                   .HasMaxLength(10)
                   .IsRequired(false);
            builder.Property(p => p.CarModel)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.CarType)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.DriverID)
                   .HasMaxLength(25)
                   .IsRequired(false);
            builder.Property(p => p.SequenceNumber)
                   .HasMaxLength(25)
                   .IsRequired(false);
            builder.Property(p => p.OwnerID)
                   .HasMaxLength(25)
                   .IsRequired(false);
            builder.Property(p => p.EstimatedAmount)
                   .HasMaxLength(50)
                   .IsRequired(false);
            builder.Property(p => p.DamageParts)
                   .HasMaxLength(250)
                   .IsRequired(false);
            builder.Property(p => p.CauseOfAccident)
                .HasMaxLength(250)
                .IsRequired(false);
            builder.Property(p => p.CreatedDate)
                   .HasColumnType("datetime");
            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.QuotationsMotorRequestVehicleDriver).WithMany(p => p.QuotationsMotorRequestVehicleDriverAccidents).HasForeignKey(p => p.VehicleDriverId).IsRequired(true);
        }

    }

    public class QuotationsMotorRequestVehicleDriverLicenseConfiguration : IEntityTypeConfiguration<QuotationsMotorRequestVehicleDriverLicense>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorRequestVehicleDriverLicense> builder)
        {
            builder.ToTable("QuotationMotorRequestsVehicleDriverLicenses");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.IsSaudiLicense)
                   .HasDefaultValue(false);
            builder.Property(p => p.CreatedDate)
                   .HasColumnType("datetime");
            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.LicenseType).WithMany(p => p.QuotationsMotorRequestVehicleDriverLicenses).HasForeignKey(p => p.LicenseTypeId).IsRequired(true);
            builder.HasOne(p => p.QuotationsMotorRequestVehicleDriver).WithMany(p => p.QuotationsMotorRequestVehicleDriverLicenses).HasForeignKey(p => p.VehicleDriverId).IsRequired(true);
            builder.HasOne(p => p.Country).WithMany(p => p.QuotationsMotorRequestVehicleDriverLicenses).HasForeignKey(p => p.CountryId).IsRequired(false);
        }

    }
}
