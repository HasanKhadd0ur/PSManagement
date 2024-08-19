using PSManagement.SharedKernel.Events;

namespace PSManagement.Domain.Employees.DomainEvents
{
    public record EmployeeWorkHoursChangedEvent(
        int EmployeeId,
        int CurrentWorkingHours,
        int NewWorkinghours
     ) : IDomainEvent;
}
