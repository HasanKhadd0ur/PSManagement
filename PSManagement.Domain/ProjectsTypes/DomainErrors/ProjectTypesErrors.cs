using PSManagement.SharedKernel.DomainErrors;

namespace PSManagement.Domain.Projects.DomainErrors
{
    public class ProjectTypesErrors
    {
        public static DomainError InvalidEntryError { get; } = new("ProjectErrors.InvalidEntry.", "Invalid project type  Data");
        public static DomainError InvalidName { get; } = new("ProjectErrors.InvalidEntry.", "the name is already exist");
        public static DomainError UnEmptyProjects { get; } = new("ProjectErrors.InvalidEntry.", "the type already has a projects ");
 
    }
}
