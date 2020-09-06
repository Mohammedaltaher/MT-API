using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class SMSLogConfiguration : IEntityTypeConfiguration<SMSLog>
    {
        public void Configure(EntityTypeBuilder<SMSLog> builder)
        {
            builder.ToTable("SMSLog");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.SenderId)
                   .HasMaxLength(500);

            builder.Property(p => p.SmsTo)
                   .HasMaxLength(20);

            builder.Property(p => p.SmsMessage)
                   .HasMaxLength(500);

            builder.Property(p => p.Status)
                   .HasMaxLength(50);

            builder.Property(p => p.CreatedDate)
                  .HasColumnType("datetime");

            builder.Property(p => p.CreatedBy)
                .HasMaxLength(450);

        }
    }
}
