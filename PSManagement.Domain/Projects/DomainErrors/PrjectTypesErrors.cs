using Ardalis.Result;
using PSManagement.SharedKernel.DomainErrors;

namespace PSManagement.Domain.Projects.DomainErrors
{
    public class PrjectTypesErrors
    {
        public static DomainError InvalidEntryError { get; } = new("ProjectErrors.InvalidEntry.", "Invalid Step  Data");
        public static DomainError InvalidName { get; } = new("ProjectErrors.InvalidEntry.", "the name is already exist");
    }
}
