namespace PSManagement.Domain.Employees.Entities
{
    /// <summary>
    /// Availability Details 
    /// </summary>
    /// Current Working Hours on our system 
    /// this info should be integrated with ldap
    public record Availability(
        int CurrentWorkingHours,
        bool IsAvailable
        );

}
