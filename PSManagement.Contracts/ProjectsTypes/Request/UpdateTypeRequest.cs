namespace PSManagement.Contracts.ProjectsTypes.Request
{
    public record UpdateTypeRequest(
    int Id,
    string TypeName,
    string Description,
    int ExpectedEffort,
    int ExpectedNumberOfWorker
    
);
}
