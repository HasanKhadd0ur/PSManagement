using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class TrackEntityConfiguration : 
        IEntityTypeConfiguration<Track> , 
        IEntityTypeConfiguration<StepTrack>, 
        IEntityTypeConfiguration<EmployeeWork>


    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {

            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tracks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

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
        public void Configure(EntityTypeBuilder<EmployeeWork> builder)
        {
            builder.HasOne(ew => ew.StepTrack)
            .WithMany(st => st.EmployeeWorks)
            .HasForeignKey(ew => ew.StepTrackId)
             .OnDelete(DeleteBehavior.Restrict); ;


            builder.HasOne(ew => ew.Employee)
            .WithMany(e => e.EmployeeWorks)
            .HasForeignKey(ew => ew.EmployeeId)
             .OnDelete(DeleteBehavior.Restrict); ;


        }
    }
}
