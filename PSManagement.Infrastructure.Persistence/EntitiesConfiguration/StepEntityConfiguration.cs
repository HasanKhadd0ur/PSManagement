using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Steps.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class StepEntityConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasOne(s => s.Project)
            .WithMany(p => p.Steps)
            .HasForeignKey(s => s.ProjectId);

            builder.HasMany(e => e.StepTracks);
        }
        
    }
}
