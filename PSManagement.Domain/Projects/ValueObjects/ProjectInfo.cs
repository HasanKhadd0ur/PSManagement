using System;

namespace PSManagement.Domain.Projects.ValueObjects
{
    public record ProjectInfo(
        string Name,
        string Code,
        string Description,
        DateTime StartDate,
        DateTime ExpectedEndDate
        );

}
