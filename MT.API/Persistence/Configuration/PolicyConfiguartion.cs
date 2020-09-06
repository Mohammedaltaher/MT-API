using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class PolicyConfiguartion : IEntityTypeConfiguration<PoliciesMotor>
    {
        public void Configure(EntityTypeBuilder<PoliciesMotor> builder)
        {
            builder.ToTable("PoliciesMotor");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.PolicyRequestId)
                   .HasMaxLength(50).HasDefaultValueSql("dbo.GeneratePolicyRequestId()");

            builder.Property(p => p.QuotationRequestRefId)
                   .HasMaxLength(50).IsRequired();

            builder.Property(p => p.InsuranceQuotationId)
                   .HasMaxLength(50).IsRequired();
            builder.Property(p => p.InsuredId).IsRequired(true);
            builder.Property(p => p.VehicleSumInsured).HasColumnType("decimal(18,2)");
            builder.Property(p => p.DeductibleAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalPremium).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalVATAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalCompCommission).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalCompCommissionVATAmount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.PolicyFilePath).IsRequired(false);
            builder.Property(p => p.PolicyFile).IsRequired(false);
            builder.Property(p => p.NajmUpdatedDate)
                 .HasColumnType("datetime").IsRequired(false);

            builder.Property(p => p.NajmVehicleReferenceId)
                 .HasMaxLength(50).IsRequired(false);

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(450);
            builder.HasOne(p => p.InsuranceCompany).WithMany(p => p.PoliciesMotors).HasForeignKey(p => p.InsuranceCompanyId).OnDelete(DeleteBehavior.NoAction).IsRequired(true);
            builder.HasOne(p => p.Client).WithMany(p => p.Policies).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.NoAction).IsRequired(false);
            builder.HasOne(p => p.ProductType).WithMany(p => p.Policies).HasForeignKey(p => p.ProductTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired(true);
        }
    }
}
