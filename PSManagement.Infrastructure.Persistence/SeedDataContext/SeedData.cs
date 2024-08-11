using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Identity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Persistence.SeedDataContext
{
    public class SeedData
    {
        public static  Task SeedAsync(ModelBuilder builder)
        {
            SeedDepartments(builder);
            SeedAdmin(builder);
            SeedRoles(builder);
            return Task.CompletedTask;
        }
        public static void SeedDepartments(ModelBuilder builder) {

            builder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "قسم المعلوميات" },
                new Department { Id = 2, Name = "قسم النظم الإلكترونيى" },
                new Department { Id = 3, Name = "شؤون الطلاب" }


                ) ;
        
        }
        public static void SeedRoles(ModelBuilder builder)
        {

            builder.Entity<Role>().HasData(
                
                new Role {Id=1, Name = "Admin" },
                new Role {Id = 2, Name = "Employee" },
                new Role {Id = 3, Name = "Scientific-Supervisor" }

                );

        }
        public static void SeedAdmin(ModelBuilder builder)
        {

            builder.Entity<User>().HasData(

                new User { Id = 2, UserName = "Admin" ,Email="Admin@Admin",HashedPassword="1234" } 
                );
            builder.Entity("UserRole").HasData(
                new Dictionary<string, object> { ["UserId"] = 1, ["RoleId"] = 1 }
            );

        }
    }
}
