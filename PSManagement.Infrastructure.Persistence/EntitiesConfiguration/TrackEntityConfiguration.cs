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
        //, 
        //IEntityTypeConfiguration<EmployeeWork>


    {
        public void Configure(EntityTypeBuilder<Track> builder)
        {

            builder.HasOne(t => t.Project)
                .WithMany(p => p.Tracks)
                .HasForeignKey(t => t.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);
            //builder.HasMany(e => e.TrackedEmployees)
            //    .WithMany(e => e.trac)
            //    .UsingEntity<EmployeeParticipate>(
            //         l => l.HasOne<Employee>(e => e.Employee)
            //             .WithMany(e => e.EmployeeParticipates)
            //             .HasForeignKey(e => e.EmployeeId),
            //         r => r.HasOne<Project>(e => e.Project)
            //             .WithMany(e => e.EmployeeParticipates)
            //             .HasForeignKey(e => e.ProjectId)
            //  );
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
            
        }

        //public void Configure(EntityTypeBuilder<EmployeeWork> builder)
        //{
        //    //builder.HasOne(ew => ew.StepTrack)
        //    //.WithMany(st => st.EmployeeWorks)
        //    //.HasForeignKey(ew => ew.StepTrackId)
        //    // .OnDelete(DeleteBehavior.Restrict); ;


        //    builder.HasOne(ew => ew.Employee)
        //    .WithMany(e => e.EmployeeWorks)
        //    .HasForeignKey(ew => ew.EmployeeId)
        //     .OnDelete(DeleteBehavior.Restrict); ;


        //}
    }
}
