using System;

namespace PSManagement.Domain.Employees.Entities
{
    /// <summary>
    /// Work Informations
    /// </summary>
    /// this record (VO) contain two proerties :
    /// Work Type : for the type of work that the employee do like programmer , designer researcher ...
    /// Work Job : for the career of the employee like doctor , engineer ,...
    public record WorkInfo (
        String WorkType , 
        String WorkJob 
        );
}
