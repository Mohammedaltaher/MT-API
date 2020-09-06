using AggriPortal.API.Domain.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace  AggriPortal.API.Persistence.Configuration
{
    public class PoliciesChartDtoConfiguartion : IEntityTypeConfiguration<ChartDto>
    {
        public void Configure(EntityTypeBuilder<ChartDto> builder)
        {
            builder.HasNoKey();
        }

    }
}
