using System;

namespace PSManagement.Domain.Tracking.ValueObjects
{
    public record EmployeeWorkInfo(
        string AssignedWork,
         string PerformedWork,
         DateTime AssignedWorkEnd
    );
}
