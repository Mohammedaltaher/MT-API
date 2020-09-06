using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ClientQuotationConfiguartion : IEntityTypeConfiguration<ClientQuotationMotor>
    {
        public void Configure(EntityTypeBuilder<ClientQuotationMotor> builder)
        {
            builder.ToTable("ClientQuotationMotor");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();
            builder.Property(p => p.QuoteReferenceId).HasMaxLength(50).HasDefaultValueSql("dbo.GenerateClientQuoteReferenceId()");
            builder.Property(p => p.InsurQuotationId).HasMaxLength(50).IsRequired();
            builder.Property(p => p.QuotationStartDate).HasColumnType("datetime");
            builder.Property(p => p.QuotationEndDate).HasColumnType("datetime");
            builder.Property(p => p.MaxLiability).HasColumnType("decimal(18,2)");
            builder.Property(p => p.DeductibleValue).HasColumnType("decimal(18,2)");
            builder.Property(p => p.TotalPremium).HasColumnType("decimal(18,2)");
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasMaxLength(50).IsRequired(false);
            builder.HasOne(p => p.Client).WithMany(p => p.ClientQuotationMotors).HasForeignKey(p => p.ClientId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.QuotationsMotorRequest).WithMany(p => p.ClientQuotationMotors).HasForeignKey(p => p.QuotationRequestId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.InsuranceCompany).WithMany(p => p.ClientQuotationMotors).HasForeignKey(p => p.InsuranceCompanyId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.QuotationsMotorResponseProduct).WithMany(p => p.ClientQuotationMotors).HasForeignKey(p => p.QuotationProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }

    public class ClientQuotationMotorBenefitConfiguartion : IEntityTypeConfiguration<ClientQuotationMotorBenefit>
    {
        public void Configure(EntityTypeBuilder<ClientQuotationMotorBenefit> builder)
        {
            builder.ToTable("ClientQuotationMotorBenefits");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.BenefitAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.BenefitVATAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.Benefit).WithMany(p => p.ClientQuotationMotorBenefits).HasForeignKey(p => p.BenefitId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.ClientQuotation).WithMany(p => p.ClientQuotationMotorBenefits).HasForeignKey(p => p.ClientQuotationId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ClientQuotationMotorPremiumBreakdownConfiguartion : IEntityTypeConfiguration<ClientQuotationMotorPremiumBreakdown>
    {
        public void Configure(EntityTypeBuilder<ClientQuotationMotorPremiumBreakdown> builder)
        {
            builder.ToTable("ClientQuotationMotorPremiumBreakdowns");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.BreakdownAmount)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.BreakdownPercentage)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.PremiumBreakdown).WithMany(p => p.ClientQuotationMotorPremiumBreakdowns).HasForeignKey(p => p.BreakdownTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.ClientQuotation).WithMany(p => p.ClientQuotationMotorPremiumBreakdowns).HasForeignKey(p => p.ClientQuotationId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ClientQuotationMotorDiscountConfiguartion : IEntityTypeConfiguration<ClientQuotationMotorDiscount>
    {
        public void Configure(EntityTypeBuilder<ClientQuotationMotorDiscount> builder)
        {
            builder.ToTable("ClientQuotationMotorDiscounts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.DiscountAmout)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.DiscountPercentage)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();
            builder.Property(p => p.NCDEligibility)
                   .HasMaxLength(50);

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.DiscountType).WithMany(p => p.ClientQuotationMotorDiscounts).HasForeignKey(p => p.DiscountTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.ClientQuotation).WithMany(p => p.ClientQuotationMotorDiscounts).HasForeignKey(p => p.ClientQuotationId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
