using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Projects.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class StepEntityConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.HasOne(s => s.Project)
            .WithMany(p => p.Steps)
            .HasForeignKey(s => s.ProjectId);

            builder.OwnsOne(c => c.StepInfo,
                p => {
                    p.Property(e => e.Description).HasColumnName("Description");
                    p.Property(e => e.StepName).HasColumnName("StepName");
                    p.Property(e => e.StartDate).HasColumnName("StartDate");
                    p.Property(e => e.Duration).HasColumnName("Duration");
                }
            );

            builder.HasMany(e => e.StepTracks);
        }
        
    }
}
