using PSManagement.SharedKernel.DomainErrors;

namespace PSManagement.Domain.Projects.DomainErrors
{
    public class StepsErrors
    {
        public static DomainError InvalidEntryError { get; } = new("StepError.InvalidEntry.", "Invalid Step  Data");
        public static DomainError InvalidWeightError { get; } = new("StepError.WeightEror", "the Step weight  incompatible");
        public static DomainError InvalidCompletionRatioError { get; } = new("StepError.CompleteionRatioEror", "the Step Completion Ratio Entered is incompatible");

    }
}
