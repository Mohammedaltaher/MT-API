using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class QuotationsMotorResponseConfiguartion : IEntityTypeConfiguration<QuotationsMotorResponse>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorResponse> builder)
        {
            builder.ToTable("QuotationsMotorResponses");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.RequestReferenceId)
                  .HasMaxLength(50).IsRequired();

            builder.Property(p => p.QuotationId)
                   .HasMaxLength(50);


            builder.Property(p => p.QuotationStartDate)
                   .HasColumnType("datetime");

            builder.Property(p => p.QuotationEndDate)
                   .HasColumnType("datetime");

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.InsuranceCompany).WithMany(p => p.QuotationsMotorResponses).HasForeignKey(p => p.InsuranceCompanyId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.QuotationsMotorRequest).WithMany(p => p.QuotationsMotorResponses).HasForeignKey(p => p.QuotationReqtId).OnDelete(DeleteBehavior.NoAction).IsRequired();

            
        }
    }

    public class QuotationProductConfiguartion : IEntityTypeConfiguration<QuotationsMotorResponseProduct>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorResponseProduct> builder)
        {
            builder.ToTable("QuotationsMotorResponsesProducts");
            
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.PolicyExpiryDate)
                   .HasColumnType("datetime");

            builder.Property(p => p.PolicyEffectiveDate)
                   .HasColumnType("datetime");
            builder.Property(p => p.MaxLiability)
                .HasColumnType("decimal(18,2)")
                .IsRequired(false);

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.QuotationsMotorResponse).WithMany(p => p.QuotationsMotorResponseProducts).HasForeignKey(p => p.QuotationResponseId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.ProductType).WithMany(p => p.QuotationsMotorResponseProducts).HasForeignKey(p => p.ProductTypeId).OnDelete(DeleteBehavior.Restrict).IsRequired();

        }
    }

    public class ProductDeductibleConfiguartion : IEntityTypeConfiguration<QuotationsMotorResponseProductDeductible>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorResponseProductDeductible> builder)
        {
            builder.ToTable("QuotationsMotorResponsesProductDeductibles");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.DeductibleValue)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.TotalPremium)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.QuotationsMotorResponseProduct).WithMany(p => p.QuotationsMotorResponseProductDeductibles).HasForeignKey(p => p.QuotationProductId).OnDelete(DeleteBehavior.Cascade);

        }
    }

    public class ProductBenefitConfiguartion : IEntityTypeConfiguration<QuotationsMotorResponseProductBenefit>
    {
        public void Configure(EntityTypeBuilder<QuotationsMotorResponseProductBenefit> builder)
        {
            builder.ToTable("QuotationsMotorResponsesProductBenefits");

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

            builder.HasOne(p => p.Benefit).WithMany(p => p.QuotationsMotorResponseProductBenefits).HasForeignKey(p => p.BenefitId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.QuotationsMotorResponseProduct).WithMany(p => p.QuotationsMotorResponseProductBenefits).HasForeignKey(p => p.QuotationProductId).OnDelete(DeleteBehavior.Cascade);


        }
    }

    public class ProductPremiumBreakdownConfiguartion : IEntityTypeConfiguration<ProductPremiumBreakdown>
    {
        public void Configure(EntityTypeBuilder<ProductPremiumBreakdown> builder)
        {
            builder.ToTable("QuotationsMotorResponsesProductPremiumBreakdowns");

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

            builder.HasOne(p => p.PremiumBreakdown).WithMany(p => p.ProductPremiumBreakdowns).HasForeignKey(p => p.BreakdownTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.QuotationsMotorResponseProductDeductible).WithMany(p => p.PremiumBreakdowns).HasForeignKey(p => p.ProductDeductibleId).OnDelete(DeleteBehavior.Cascade);
        }
    }

    public class ProductDiscountConfiguartion : IEntityTypeConfiguration<ProductDiscount>
    {
        public void Configure(EntityTypeBuilder<ProductDiscount> builder)
        {
            builder.ToTable("QuotationsMotorResponsesProductDiscounts");

            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.DiscountAmout)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.DiscountPercentage)
                   .HasColumnType("decimal(18,2)")
                   .IsRequired();

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                   .HasMaxLength(450);

            builder.HasOne(p => p.DiscountType).WithMany(p => p.ProductDiscounts).HasForeignKey(p => p.DiscountTypeId).OnDelete(DeleteBehavior.NoAction).IsRequired();
            builder.HasOne(p => p.NCDFreeYear).WithMany(p => p.ProductDiscounts).HasForeignKey(p => p.NCDFreeYearsId).OnDelete(DeleteBehavior.Restrict).IsRequired(false);
            builder.HasOne(p => p.QuotationsMotorResponseProductDeductible).WithMany(p => p.Discounts).HasForeignKey(p => p.ProductDeductibleId).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
