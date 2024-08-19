using FluentValidation;

namespace PSManagement.Application.Projects.UseCases.Commands.AddProjectStep
{
    public class AddProjectStepCommandValidator : AbstractValidator<AddProjectStepCommand>
    {
        public AddProjectStepCommandValidator()
        {
            RuleFor(x => x.Weight)
                .GreaterThan(0)
                .LessThan(101);
            
            RuleFor(x => x.StepInfo.StartDate)
                .GreaterThan(System.DateTime.Now);
            
            RuleFor(x => x.StepInfo.Duration)
                .GreaterThan(0);
            
            RuleFor(x => x.StepInfo.Description)
                .NotEmpty()
                .MinimumLength(5);

            RuleFor(x => x.StepInfo.StepName)
                .NotEmpty()
                .MinimumLength(5);

        }
    }
}
