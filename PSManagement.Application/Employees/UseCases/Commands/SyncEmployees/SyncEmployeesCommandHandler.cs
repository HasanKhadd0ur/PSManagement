using Ardalis.Result;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Commands.SyncEmployeesData
{
    public class SyncEmployeesCommandHandler : ICommandHandler<SyncEmployeesCommand, Result<SyncResponse>>
    {
        private readonly ISyncEmployeesService _syncEmployeesService;
        private readonly IEmployeesProvider _employeesProvider;

        public SyncEmployeesCommandHandler(
            ISyncEmployeesService syncEmployeesService,
            IEmployeesProvider employeesProvider)
        {
            _syncEmployeesService = syncEmployeesService;
            _employeesProvider = employeesProvider;
        }

        public async Task<Result<SyncResponse>> Handle(SyncEmployeesCommand request, CancellationToken cancellationToken)
        {
            SyncResponse response = await _syncEmployeesService.SyncEmployees(_employeesProvider);

            return response;

        }
    }
}
