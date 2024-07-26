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
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasAnnotation("Relational:Collation", "Arabic_CI_AS");
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.OwnsOne(c => c.Address);

            });
            modelBuilder.Entity<Customer>(builder =>
            {
                builder.OwnsMany(c => c.ContactInfo, contactInfoBuilder =>
                {
                    contactInfoBuilder.OwnsOne(c => c.MobileNumber);
                    contactInfoBuilder.OwnsOne(c => c.PhoneNumber);
                });
            });

        }

    }
}
