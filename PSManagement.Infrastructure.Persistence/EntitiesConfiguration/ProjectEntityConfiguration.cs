using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Projects.Aggregate;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {

            builder.OwnsOne(c => c.ProjectAggreement,
                p => { 
                    p.Property(e => e.AggreementDate).HasColumnName("AggreementDate");
                    p.Property(e => e.AggreementNumber).HasColumnName("AggreementNumber");
                }
            );
            builder.OwnsOne(c => c.ProjectInfo,
                p => {
                    p.Property(e => e.Description).HasColumnName("Description");
                    p.Property(e => e.Code).HasColumnName("Code");
                    p.Property(e => e.Name).HasColumnName("Name");
                    

                }
            );
            builder.Property(e => e.Participants);
            builder.OwnsOne(c => c.ProposalInfo,
                    p => {
                        p.Property(e => e.ProposingBookDate).HasColumnName("ProposingBookDate");
                        p.Property(e => e.ProposingBookNumber).HasColumnName("ProposingBookNumber");
                    }
            );
            builder.HasMany(e => e.Tracks).WithOne(e => e.Project).HasForeignKey(e => e.ProjectId);
            builder.HasOne(e => e.ProjectType).WithMany(r => r.Projects);
            builder.Ignore(e => e.Participants);
        }
    }
}
