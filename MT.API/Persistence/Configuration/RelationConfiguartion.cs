using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class RelationConfiguartion : IEntityTypeConfiguration<Relation>
    {
        public void Configure(EntityTypeBuilder<Relation> builder)
        {
            builder.ToTable("SettingsRelations");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Id).HasColumnName("Id").ValueGeneratedNever();

            builder.Property(p => p.Name)
                   .HasMaxLength(50);

            builder.Property(p => p.NameAr)
                   .HasMaxLength(50);


            #region Default Data
            builder.HasData(
                new Relation { Id = 1, Name = "Father", NameAr = "أب" },
                new Relation { Id = 2, Name = "Mother", NameAr = "أم" },
                new Relation { Id = 3, Name = "Husband", NameAr = "زوج" },
                new Relation { Id = 4, Name = "Wife", NameAr = "زوجة" },
                new Relation { Id = 5, Name = "Son", NameAr = "أبن" },
                new Relation { Id = 6, Name = "Daughter", NameAr = "إبنة" },
                new Relation { Id = 7, Name = "Brother", NameAr = "أخ" },
                new Relation { Id = 8, Name = "Sister", NameAr = "أخت" },
                new Relation { Id = 9, Name = "Contract", NameAr = "عقد عمل" },
                new Relation { Id = 10, Name = "Sponsor", NameAr = "علي كفالة" });
            #endregion
        }
    }
}
