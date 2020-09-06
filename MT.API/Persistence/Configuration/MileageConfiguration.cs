using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class MileageConfiguration : IEntityTypeConfiguration<Mileage>
    {
        public void Configure(EntityTypeBuilder<Mileage> builder)
        {
            builder.ToTable("SettingsMileages");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(50);



            builder.Property(p => p.NameAr)
                   .HasMaxLength(50);



            #region Default Data
            builder.HasData(
                new Mileage { Id = 1, Name = "Less than 50,000 KM", NameAr = "أقل من 50000   ( كيلومتر )" },
                new Mileage { Id = 2, Name = "50,000 - 100,000 KM", NameAr = "من 50000 إلى 100000  ( كيلومتر )" },
                new Mileage { Id = 3, Name = "More than 100,000 KM", NameAr = "أكثر من 100000  ( كيلومتر )" });
            #endregion
        }
    }
}
