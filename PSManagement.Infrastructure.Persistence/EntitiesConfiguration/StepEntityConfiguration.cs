using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Steps.Aggregate;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class StepEntityConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {

            
        }
    }
}
