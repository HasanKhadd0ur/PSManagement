using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Employees.Repositories
{
    public interface IEmployeesRepository : IRepository<Employee>
    {
    }
}
