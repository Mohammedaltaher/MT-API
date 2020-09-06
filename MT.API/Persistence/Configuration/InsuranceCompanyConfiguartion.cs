using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class InsuranceCompanyConfiguartion : IEntityTypeConfiguration<InsuranceCompany>
    {
        public void Configure(EntityTypeBuilder<InsuranceCompany> builder)
        {
            builder.ToTable("SettingsInsuranceCompanies");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            builder.Property(p => p.Logo)
                   .HasMaxLength(500);

            builder.Property(p => p.PhoneNumber)
                   .HasMaxLength(25);

            builder.Property(p => p.Address)
                  .HasMaxLength(500);

            builder.Property(p => p.QuotationEndPoint)
                  .HasMaxLength(250);

            builder.Property(p => p.IssuePolicyEndPoint)
                  .HasMaxLength(250);

            builder.Property(p => p.HttpClientName)
                  .HasMaxLength(50);

            builder.Property(p => p.CreatedDate)
                 .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                 .HasMaxLength(450);
        }
    }
}
