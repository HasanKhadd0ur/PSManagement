using PSManagement.Application.Contracts.Authentication;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Identity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Infrastructure.Services.Providers
{
    public class EmployeesProvider :IEmployeesProvider
    {
        private readonly static List<Employee> _employees = new()
        {

            new Employee { Availability = new Availability(0, true), PersonalInfo = new PersonalInfo("Hasan", "Khaddour"), HIASTId = 1, User = new User { UserName = "Hasan@mail.hiast", Email = "Hasan@mail.hiast",HashedPassword="1234" },DepartmentId=1, WorkInfo = new WorkInfo("Researcher", "Worker") },
            new Employee { Availability = new Availability(0, true), PersonalInfo = new PersonalInfo("Mhd", "hasan"), HIASTId = 5, User = new User { UserName = "mhd@mail.hiast", Email = "mhd@mail.hiast", HashedPassword = "1234" }, DepartmentId = 1, WorkInfo = new WorkInfo("worker", "Worker") },
            new Employee { Availability = new Availability(0, true), PersonalInfo = new PersonalInfo("mahmoud", "hasan"), HIASTId = 6, User = new User { UserName = "mahmoud@mail.hiast", Email = "mahmoud@mail.hiast", HashedPassword = "1234" }, DepartmentId = 2, WorkInfo = new WorkInfo("worker", "Worker") },
            new Employee { Availability = new Availability(0, true), PersonalInfo = new PersonalInfo("ali", "ahmad"), HIASTId = 8, User = new User { UserName = "rawad@mail.hiast", Email = "rawad@mail.hiast", HashedPassword = "1234" }, DepartmentId = 2, WorkInfo = new WorkInfo("worker", "Worker") }

        };
        public Task<IEnumerable<Employee>> FetchEmployees()
        {
            return Task.FromResult(_employees.AsEnumerable());
        }
    }
}
