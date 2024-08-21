namespace PSManagement.Domain.Projects.ValueObjects
{
    public record ProjectClassification(
        string ProjectNature,
        string ProjectStatus,
        string ProjectType
        );

}
