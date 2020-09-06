using AggriPortal.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class APILogHistoryConfiguartion : IEntityTypeConfiguration<APILogHistory>
    {
        public void Configure(EntityTypeBuilder<APILogHistory> builder)
        {
            builder.ToTable("APILogHistory");

            builder.Property(p => p.CreatedDate)
                   .HasColumnType("datetime");
        }
    }
}
