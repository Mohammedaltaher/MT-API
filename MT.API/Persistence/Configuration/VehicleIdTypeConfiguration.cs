using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class VehicleIdTypeConfiguration : IEntityTypeConfiguration<VehicleIdType>
    {
        public void Configure(EntityTypeBuilder<VehicleIdType> builder)
        {
            builder.ToTable("SettingsVehicleIdTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(150);



            builder.Property(p => p.NameAr)
                   .HasMaxLength(150);



            #region Default Data
            builder.HasData(
                new VehicleIdType { Id = 1, Name = "Sequence Number", NameAr = "الرقم التسلسلي" },
                new VehicleIdType { Id = 2, Name = "Custom Card", NameAr = "البطاقة الجمركية" });
            #endregion
        }
    }
}
