using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class NCDFreeYearConfiguration : IEntityTypeConfiguration<NCDFreeYear>
    {
        public void Configure(EntityTypeBuilder<NCDFreeYear> builder)
        {
            builder.ToTable("SettingsNCDFreeYears");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(500);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(500);

            #region Default Data
            builder.HasData(
                new NCDFreeYear { Id = 0, Name = "Not eligible", NameAr = "لا يوجد" },
                new NCDFreeYear { Id = 1, Name = "‘1’ Year Free Claim ", NameAr = "1 سنة" },
                new NCDFreeYear { Id = 2, Name = "‘2’ Year Free Claim ", NameAr = "2 سنة" },
                new NCDFreeYear { Id = 3, Name = "‘3’ Year Free Claim ", NameAr = "3 سنوات" },
                new NCDFreeYear { Id = 4, Name = "‘4’ Year Free Claim", NameAr = "4 سنوات" },
                new NCDFreeYear { Id = 5, Name = "‘5’ Year Free Claim ", NameAr = "5 سنوات" }
                );
            #endregion

        }
    }
}
