using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class ProjectEntityConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            builder.HasMany(e => e.Participants)
               .WithMany(e => e.Projects)
               .UsingEntity<EmployeeParticipate>(
                                l => l.HasOne<Employee>(e => e.Employee)
                                    .WithMany(e => e.EmployeeParticipates)
                                    .HasForeignKey(e => e.EmployeeId),
                                r => r.HasOne<Project>(e => e.Project)
                                    .WithMany(e => e.EmployeeParticipates)
                                    .HasForeignKey(e => e.ProjectId)
                         );

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
                    p.Property(e => e.StartDate).HasColumnName("StartDate");
                    p.Property(e => e.ExpectedEndDate).HasColumnName("ExpectedEndDate");


                }
            );
            builder.HasOne(e => e.TeamLeader)
               .WithMany()
               .HasForeignKey(e => e.TeamLeaderId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

            builder.HasOne(e => e.ProjectManager)
               .WithMany()
               .HasForeignKey(e => e.ProjectManagerId)
               .OnDelete(DeleteBehavior.Restrict)
               .IsRequired(false);

            builder.HasOne(e => e.Proposer).WithMany().HasForeignKey(e=>e.ProposerId);
            builder.OwnsOne(c => c.ProposalInfo,
                    p => {
                        p.Property(e => e.ProposingBookDate).HasColumnName("ProposingBookDate");
                        p.Property(e => e.ProposingBookNumber).HasColumnName("ProposingBookNumber");
                    }
            );
            builder.OwnsOne(c => c.FinancialFund,
                    p => {
                        p.Property(e => e.FinancialStatus).HasColumnName("FinicialStatus");
                        p.Property(e => e.Source).HasColumnName("FinicialSource");
                    }
            );

            builder.Property(p => p.CurrentState).HasDefaultValue("Proposed");
            
            builder.HasMany(e => e.Attachments).WithOne().HasForeignKey(e => e.ProjectId);
            builder.HasMany(e => e.FinancialSpending).WithOne().HasForeignKey(e=>e.ProjectId);
            builder.HasMany(e => e.Tracks).WithOne(e => e.Project).HasForeignKey(e => e.ProjectId);
            
        }
    }
}
