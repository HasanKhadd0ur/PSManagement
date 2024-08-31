using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Identity.Constants;
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

        #region Configure Departments 
        public static void SeedDepartments(ModelBuilder builder) {

            builder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "قسم المعلوميات" },
                new Department { Id = 2, Name = "قسم النظم الإلكترونية" },
                new Department { Id = 3, Name = "قسم الميكاترونيكس" },
                new Department { Id = 4, Name = "قسم الفيزياء" },
                new Department { Id = 5, Name = "مديرية التطوير والخدمات البرمجية" },
                new Department { Id = 6, Name = "شؤون الطلاب" }


                ) ;
        
        }
        #endregion Configure Departments 

        #region Seed Roles 
        public static void SeedRoles(ModelBuilder builder)
        {

            builder.Entity<Role>().HasData(
                new Role {Id=1, Name = RolesNames.ADMIN },
                new Role {Id = 2, Name = RolesNames.EMPLOYEE},
                new Role {Id = 4, Name = RolesNames.PROJECTS_PLANNER },
                new Role { Id = 5, Name =RolesNames.SCIENTIFIC_DEPUTY},
                new Role { Id = 6, Name = RolesNames.CUSTOMERS_PLANNER }


                );

        }

        #endregion Seed Roles 

        #region Configure Admin 
        public static void SeedAdmin(ModelBuilder builder)
        {

            builder.Entity<User>().HasData(

                new User { Id = 2, UserName = "Admin" ,Email="Admin@Admin",HashedPassword="1234" } 
                );
            builder.Entity("UserRole").HasData(
                new Dictionary<string, object> { ["UserId"] = 1, ["RoleId"] = 1 }
            );

        }

        #endregion Configure Admin 
    }
}
