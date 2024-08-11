using PSManagement.Domain.Employees.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Providers
{
    public interface IEmployeesProvider
    {
        public Task<IEnumerable<Employee>> FetchEmployees();
    }
}
