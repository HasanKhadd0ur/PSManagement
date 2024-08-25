namespace PSManagement.Contracts.ProjectsTypes.Request
{
    public record ProjectTypeResponse(
        int Id,
        string TypeName ,
        string Description,
        int ExpectedEffort
    );
    
}
