using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class PromoCodeConfiguration : IEntityTypeConfiguration<PromoCode>
    {
        public void Configure(EntityTypeBuilder<PromoCode> builder)
        {
            builder.ToTable("SettingsPromoCodes");
            builder.HasKey(p => p.Code);

            builder.Property(p => p.Code).IsRequired(true);

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250)
                   .IsRequired();

        }
    }
}
