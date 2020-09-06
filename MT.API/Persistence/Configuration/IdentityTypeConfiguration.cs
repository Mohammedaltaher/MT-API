using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class IdentityTypeConfiguration : IEntityTypeConfiguration<IdentityType>
    {
        public void Configure(EntityTypeBuilder<IdentityType> builder)
        {
            builder.ToTable("SettingsIdentityTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250)
                   .IsRequired();

            #region Default Data
            builder.HasData(
                new IdentityType { Id = 1, Name = "Citizen", NameAr = "مواطن" },
                new IdentityType { Id = 2, Name = "Resident", NameAr = "مقيم" }
                );
            #endregion
        }
    }
}
