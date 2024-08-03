namespace PSManagement.Domain.Employees.Entities
{
    public record Availability(
        int CurrentWorkingHours,
        bool IsAvailable
        );

}
