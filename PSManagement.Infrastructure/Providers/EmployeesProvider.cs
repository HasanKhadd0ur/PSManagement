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

            new Employee { Availability = new Availability(0, true), PersonalInfo = new PersonalInfo("Hasan", "Khaddour"), HIASTId = 1, User = new User { UserName = "Hasan@mail.hiast", Email = "Hasan@mail.hiast" }, WorkInfo = new WorkInfo("Researcher", "Worker") }

        };
        public Task<IEnumerable<Employee>> FetchEmployees()
        {
            return Task.FromResult(_employees.AsEnumerable());
        }
    }
}
