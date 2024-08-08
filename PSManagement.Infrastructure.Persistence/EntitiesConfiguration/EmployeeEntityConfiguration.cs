using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PSManagement.Domain.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.EntitiesConfiguration
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {

            builder.OwnsOne(c => c.Availability, 
                p => {
                    p.Property(e => e.IsAvailable).HasColumnName("IsAvailable");
                    p.Property(e => e.CurrentWorkingHours).HasColumnName("CurrentWorkingHours");
                }
            );
            builder.OwnsOne(c => c.WorkInfo,
                p => {
                    p.Property(e => e.WorkJob).HasColumnName("WorkJob");
                    p.Property(e => e.WorkType).HasColumnName("WorkType");
                }
            );

            builder.OwnsOne(c => c.PersonalInfo,
                    p => {
                        p.Property(e => e.LastName).HasColumnName("LastName");
                        p.Property(e => e.FirstName).HasColumnName("FirstName");
                    }
            );

            builder.HasOne(e => e.User)
                .WithOne(e=> e.Employee)
                .HasForeignKey<Employee>(e => e.UserId); ;


            
        }
    }
}
