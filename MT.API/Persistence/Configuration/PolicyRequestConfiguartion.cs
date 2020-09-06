using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class PolicyRequestConfiguartion : IEntityTypeConfiguration<PolicyRequest>
    {
        public void Configure(EntityTypeBuilder<PolicyRequest> builder)
        {
            builder.ToTable("PoliciesMotorRequests");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.PolicyRequestRefId)
                   .HasMaxLength(50).HasDefaultValueSql("dbo.GeneratePolicyRequestId()");

            builder.Property(p => p.InsurQuotationId)
                   .HasMaxLength(50).IsRequired();

            builder.Property(p => p.PaymentAmount)
                   .HasColumnType("decimal(18,2)").IsRequired(false);

            builder.Property(p => p.InsuredMobileNumber).HasMaxLength(25).IsRequired(false);
            builder.Property(p => p.InsuredEmail).HasMaxLength(500).IsRequired(false);
            builder.Property(p => p.InsuredIBAN).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.PaymentInvoiceId).HasMaxLength(100).IsRequired(false);
            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");
            builder.Property(p => p.CreatedBy)
                .HasMaxLength(450);

            builder.HasOne(p => p.InsuranceCompany).WithMany(p => p.PolicyRequests).HasForeignKey(p => p.InsuranceCompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Bank).WithMany(p => p.PolicyRequests).HasForeignKey(p => p.InsuredBankId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.PaymentMethod).WithMany(p => p.PolicyRequests).HasForeignKey(p => p.PaymentMethodId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(p => p.Client).WithMany(p => p.PolicyRequests).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.Cascade).IsRequired(true);

        }
    }
}
