using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class PaymentMethodConfiguartion : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("SettingsPaymentMethods");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);

            #region Default Data
            builder.HasData(
                new PaymentMethod { Id = 1, Name = "Visa Card", NameAr = "فيزا كارت" },
                new PaymentMethod { Id = 2, Name = "Mastercard", NameAr = "ماستركارت" },
                new PaymentMethod { Id = 3, Name = "Mada", NameAr = "بطاقة مدى" },
                new PaymentMethod { Id = 4, Name = "Sadad Bill", NameAr = "فواتير سداد" }
                );
            #endregion
        }
    }
}
