using Microsoft.EntityFrameworkCore;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Identity.Entities;
using PSManagement.Domain.Projects.Entities;
using PSManagement.Domain.Reports.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.Infrastructure.Persistence.SeedDataContext;
using PSManagement.SharedKernel.Entities;

namespace PSManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }
        public DbSet<Report> Reports { get; set; }
        public DbSet<ReportResult> ReportResults { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permission { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Step> Steps { get; set; }

        public DbSet<Track> Tracks { get; set; }

        public DbSet<StepTrack> StepTracks { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
     //       modelBuilder.Entity<BaseEntity>().Ignore(e => e.Events);
            
            SeedData.SeedAsync(modelBuilder).Wait();

            base.OnModelCreating(modelBuilder);

            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

        }

    }
}
