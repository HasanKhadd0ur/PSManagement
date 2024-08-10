using PSManagement.Domain.Employees.Entities;
using System.Collections.Generic;

namespace PSManagement.Application.Contracts.Providers
{
    public interface IDepartmentsProvider
    {
        public ICollection<Department> FetchDepartments();
    }
}
