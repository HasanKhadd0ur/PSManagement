using Ardalis.Result;
using PSManagement.Domain.Employees.DomainErrors;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Commands.UpdateEmployeeWorkHours
{
    public class UpdateEmployeeWorkHoursCommandHandler : ICommandHandler<UpdateEmployeeWorkHoursCommand, Result>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly static int _workHourLimit = 70;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateEmployeeWorkHoursCommandHandler(
            IEmployeesRepository employeesRepository,
            IUnitOfWork unitOfWork)
        {
            _employeesRepository = employeesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(UpdateEmployeeWorkHoursCommand request, CancellationToken cancellationToken)
        {
            Employee employee =await _employeesRepository.GetByIdAsync(request.EmployeeId);
            
            if (employee is null) {

                return Result.Invalid(EmployeesErrors.EmployeeUnExist);
            }
            // check the work hours limitation boundries  
            if (request.WorkingHour < _workHourLimit && request.WorkingHour > 0)
            {
                // this method will publish the events of changing the work hours
                employee.UpdateWorkHours(request.WorkingHour);

                await _employeesRepository.UpdateAsync(employee);

                await _unitOfWork.SaveChangesAsync();

                return Result.Success();
            }
            else {

                return Result.Invalid(EmployeesErrors.WorkHourLimitExceeded);
            
            }

        }
    }

}
