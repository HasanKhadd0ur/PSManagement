using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.FinincialSpending.Repositories;
using PSManagement.Infrastructure.Persistence.Repositories.Base;

namespace PSManagement.Infrastructure.Persistence.Repositories.EmployeeRepository
{
    public class EmployeesRespository : BaseRepository<Employee>, IEmployeesRepository
    {
        public EmployeesRespository(AppDbContext context) : base(context)
        {
        }
    }

}
