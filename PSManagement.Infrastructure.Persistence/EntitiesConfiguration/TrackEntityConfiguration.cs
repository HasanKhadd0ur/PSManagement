using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class TrackEntityConfiguration : 
        IEntityTypeConfiguration<Track> , 
        IEntityTypeConfiguration<StepTrack>,
        IEntityTypeConfiguration<EmployeeTrack>
        
    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {

            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tracks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.Ignore(e => e.TrackedEmployees);

            builder.OwnsOne(e => e.TrackInfo, p =>
            {
                p.Property(e => e.IsCompleted).HasColumnName("IsCompleted").HasDefaultValue(false);
                p.Property(e => e.StatusDescription).HasColumnName("StatusDescription");

                p.Property(e => e.TrackDate).HasColumnName("TrackDate");


            });
        }
        public void Configure(EntityTypeBuilder<StepTrack> builder)
        {
            builder.HasOne(st => st.Step)
            .WithMany(s => s.StepTracks)
            .HasForeignKey(st => st.StepId)
             .OnDelete(DeleteBehavior.Restrict); ;

            builder.HasOne(st => st.Track)
            .WithMany(t => t.StepTracks)
            .HasForeignKey(st => st.TrackId)
             .OnDelete(DeleteBehavior.Restrict); ;



        }

        public void Configure(EntityTypeBuilder<EmployeeTrack> builder)
        {
            builder.HasOne(st => st.Employee)
                .WithMany(s => s.EmployeeTracks)
                .HasForeignKey(st => st.EmloyeeId)
            ;

            builder.OwnsOne(e => e.EmployeeWorkInfo, p =>
            {
                p.Property(e => e.AssignedWork).HasColumnName("AssignedWork");
                p.Property(e => e.AssignedWorkEnd).HasColumnName("AssignedWorkEnd");
                p.Property(e => e.PerformedWork).HasColumnName("PerformedWork");
                
            });

            builder.OwnsOne(e => e.EmployeeWork, p =>
            {
                p.Property(e => e.ContributingRatio).HasColumnName("ContributingRatio");
                p.Property(e => e.WorkedHours).HasColumnName("WorkedHours");
                p.Property(e => e.AssignedWorkingHours).HasColumnName("AssignedWorkingHours");

            });

        }

    }
}
