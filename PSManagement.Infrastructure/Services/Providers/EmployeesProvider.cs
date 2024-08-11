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
        private static List<Employee> Employees = new List<Employee> 
        { 
            new Employee{Availability=new Availability(0,true),PersonalInfo= new ("Hasan","Khaddour"),HIASTId=1,User = new User{UserName="Hasan@mail.hiast",Email="Hasan@mail.hiast" },WorkInfo = new WorkInfo("Researcher","Worker") },

        };
        public Task<IEnumerable<Employee>> FetchEmployees()
        {
            return Task.FromResult(Employees.AsEnumerable());
        }
    }
}
