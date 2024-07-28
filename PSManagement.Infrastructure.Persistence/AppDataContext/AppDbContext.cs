using Microsoft.EntityFrameworkCore;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Identity.Aggregate;

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

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
            
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");

        }

    }
}
