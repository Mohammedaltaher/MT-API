using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ClientPaymentConfiguartion : IEntityTypeConfiguration<ClientPayment>
    {
        public void Configure(EntityTypeBuilder<ClientPayment> builder)
        {
            builder.ToTable("ClientsPayments");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.PaymentReferenceId).HasDefaultValueSql("dbo.GeneratePaymentReferenceId()");
            builder.Property(p => p.CardHolder).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.CardToken).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.CardBin).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.CardLast4).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.ExpiryMonth).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.ExpiryYear).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.PaymentResponseResultCode).HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Amount).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Currency).HasMaxLength(50).IsRequired();
            builder.Property(p => p.CreatedDate).HasColumnType("datetime");
            builder.Property(p => p.UpdatedDate).HasColumnType("datetime");
            builder.Property(p => p.CreatedBy).HasMaxLength(450).IsRequired(false);
            builder.HasOne(p => p.Client).WithMany(p => p.ClientPayments).HasForeignKey(p => p.ClientId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.PaymentMethod).WithMany(p => p.ClientPayments).HasForeignKey(p => p.PaymentMethodId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.ClientQuotation).WithMany(p => p.ClientPayments).HasForeignKey(p => p.ClientQuotationId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
