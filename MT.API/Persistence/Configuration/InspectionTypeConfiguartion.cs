using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class InspectionTypeConfiguartion : IEntityTypeConfiguration<InspectionType>
    {
        public void Configure(EntityTypeBuilder<InspectionType> builder)
        {
            builder.ToTable("SettingsInspectionTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id");

            builder.Property(p => p.Name)
                   .HasMaxLength(250);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250);


            #region Default Data
            builder.HasData(
                new InspectionType { Id = 1, Name = "Waiting Vehicle Photo", NameAr = "تحميل صور المركبة" },
                new InspectionType { Id = 2, Name = "Physical Inspection", NameAr = "الفحص الميداني للمركبة" });
            #endregion
        }
    }
}
