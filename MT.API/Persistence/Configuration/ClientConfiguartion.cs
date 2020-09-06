using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class ClientConfiguartion : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clients");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.MiddleName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastName).HasMaxLength(50).IsRequired();
            builder.Property(p => p.FirstNameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.MiddleNameAr).HasMaxLength(50).IsRequired();
            builder.Property(p => p.LastNameAr).HasMaxLength(50).IsRequired();
            builder.HasOne(p => p.IdentityType).WithMany(p => p.Clients).HasForeignKey(p => p.IdentityTypeId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Gender).WithMany(p => p.Clients).HasForeignKey(p => p.GenderId)
                   .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.IdentityNumber).IsRequired();
            builder.HasOne(p => p.IdentityIssuePlace).WithMany(p => p.IdentityIssuePlaceClients).HasForeignKey(p => p.IdentityIssuePlaceId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.Nationality).WithMany(p => p.Clients).HasForeignKey(p => p.NationalityId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.SocialStatus).WithMany(p => p.Clients).HasForeignKey(p => p.SocialStatusId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(p => p.EducationLevel).WithMany(p => p.Clients).HasForeignKey(p => p.EducationLevelId)
                .OnDelete(DeleteBehavior.NoAction);
            builder.Property(p => p.BuildingNumber).HasMaxLength(15);
            builder.Property(p => p.Street).HasMaxLength(500);
            builder.Property(p => p.District).HasMaxLength(500);
            builder.Property(p => p.PostalCode).HasMaxLength(50);
            builder.Property(p => p.AdditionalNumber).HasMaxLength(10);
            builder.Property(p => p.PhoneNumber).HasMaxLength(20);
            builder.Property(p => p.Email).HasMaxLength(500);
            builder.Property(p => p.IBAN).HasMaxLength(100);

            builder.Property(p => p.ApplicationUserId)
                   .HasMaxLength(128);
        }
    }
}
