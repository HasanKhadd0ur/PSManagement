namespace PSManagement.Domain.Employees.Entities
{
    /// <summary>
    /// Personal Information
    /// </summary>
    /// this cvalue object record represent the 
    /// personal information that we care about it in our case 
    /// we only need the first and last name 
    public record PersonalInfo(
        string FirstName,
        string LastName
        );

}
