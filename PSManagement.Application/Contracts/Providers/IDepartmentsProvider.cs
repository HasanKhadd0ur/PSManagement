using PSManagement.Domain.Employees.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.Providers
{
    public interface IDepartmentsProvider
    {
        public Task<ICollection<Department>> FetchDepartments();
    }
}
