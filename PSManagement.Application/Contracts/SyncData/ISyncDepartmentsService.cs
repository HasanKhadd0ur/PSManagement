using PSManagement.Application.Contracts.Providers;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.SyncData
{
    public interface ISyncDepartmentsService
    {
        public Task<SyncResponse> SyncEmployees(IEmployeesProvider employeesProvider);
    }
}
