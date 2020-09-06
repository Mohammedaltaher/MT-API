using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    /// <summary>
    /// Product Type Fluent API Config.
    /// </summary>
    public class ProductTypeConfiguration : IEntityTypeConfiguration<ProductType>
    {
        public void Configure(EntityTypeBuilder<ProductType> builder)
        {
            builder.ToTable("SettingsProductTypes");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedOnAdd();

            builder.Property(p => p.Name)
                   .HasMaxLength(250)
                   .IsRequired();

            builder.Property(p => p.NameAr)
                   .HasMaxLength(250)
                   .IsRequired();
            builder.Property(p => p.CompCommissionPerc).HasColumnType("decimal(18,2)");

            #region Default Data
            builder.HasData(
                new ProductType { Id = 1, Name = "Third-Party Vehicle Insurance", NameAr = "تأمين مركبات طرف ثالث (ضد الغير)" },
                new ProductType { Id = 2, Name = "Comprehensive Vehicle Insurance", NameAr = "تأمين مركبات شامل" });
            #endregion
        }
    }
}
