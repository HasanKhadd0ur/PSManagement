using Microsoft.EntityFrameworkCore;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Departments.Aggregate;
using PSManagement.Domain.Employees.Aggregate;
using PSManagement.Domain.Identity.Aggregate;
using PSManagement.Domain.Projects.Aggregate;
using PSManagement.Domain.Steps.Aggregate;
using PSManagement.Domain.Steps.Entities;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;

namespace PSManagement.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Step> Steps { get; set; }

        public DbSet<Item> Items { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<EmployeeTrack> EmployeeTraks { get; set; }

        public DbSet<StepTrack> StepTracks { get; set; }




        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

        }

    }
}
