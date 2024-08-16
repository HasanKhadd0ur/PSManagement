namespace PSManagement.Domain.Tracking.ValueObjects
{
    public record EmployeeWork(
        int AssignedWorkingHours,
        int WorkedHours,
        int ContributingRatio

    );
}
