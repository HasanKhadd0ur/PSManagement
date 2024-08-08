﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.Aggregate;
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


            builder.OwnsOne(c => c.ProposalInfo,
                    p => {
                        p.Property(e => e.ProposingBookDate).HasColumnName("ProposingBookDate");
                        p.Property(e => e.ProposingBookNumber).HasColumnName("ProposingBookNumber");
                    }
            );
            builder.OwnsOne(c => c.FinincialFund,
                    p => {
                        p.Property(e => e.FinicialStatus).HasColumnName("FinicialStatus");
                        p.Property(e => e.Source).HasColumnName("FinicialSource");
                    }
            );

            builder.HasMany(e => e.Tracks).WithOne(e => e.Project).HasForeignKey(e => e.ProjectId);
            
        }
    }
}