using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PSManagement.Domain.Employees.Entities;
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
            return Task.CompletedTask;
        }
        public static void SeedDepartments(ModelBuilder builder) {

            builder.Entity<Department>().HasData(
                new Department { Id = 1, Name = "قسم المعلوميات" },
                new Department { Id = 2, Name = "قسم النظم الإلكترونيى" },
                new Department { Id = 3, Name = "شؤون الطلاب" }


                ) ;
        
        }

    }
}
