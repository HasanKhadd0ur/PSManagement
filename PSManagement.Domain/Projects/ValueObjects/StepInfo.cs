using System;

namespace PSManagement.Domain.Projects.ValueObjects
{
    public record StepInfo(
        string StepName,
        string Description,
        DateTime StartDate,
        int Duration
     );

}
