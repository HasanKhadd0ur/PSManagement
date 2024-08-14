using Ardalis.Result;
using PSManagement.Domain.Employees.DomainErrors;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Commands.UpdateEmployeeWorkHours
{
    public class UpdateEmployeeWorkHoursCommandHandler : ICommandHandler<UpdateEmployeeWorkHoursCommand, Result>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly static int _workHourLimit = 70;

        public UpdateEmployeeWorkHoursCommandHandler(IEmployeesRepository employeesRepository)
        {
            _employeesRepository = employeesRepository;
        }

        public async Task<Result> Handle(UpdateEmployeeWorkHoursCommand request, CancellationToken cancellationToken)
        {
            Employee employee =await _employeesRepository.GetByIdAsync(request.EmployeeId);
            if (request.WorkingHour < _workHourLimit)
            {
                employee.Availability = new(request.WorkingHour, employee.Availability.IsAvailable);

                await _employeesRepository.UpdateAsync(employee);

                return Result.Success();
            }
            else {

                return Result.Invalid(EmployeesErrors.WorkHourLimitExceeded);
            
            }

        }
    }

}
