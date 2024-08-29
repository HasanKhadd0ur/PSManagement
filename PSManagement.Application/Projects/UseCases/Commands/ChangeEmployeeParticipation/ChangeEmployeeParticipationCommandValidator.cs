using FluentValidation;
using PSManagement.Application.Projects.UseCases.Commands.ChangeProjectManager;

namespace PSManagement.Application.Projects.UseCases.Commands.ChangeEmployeeParticipation
{
    public class ChangeEmployeeParticipationCommandValidator : AbstractValidator<ChangeEmployeeParticipationCommand>
    {
        public ChangeEmployeeParticipationCommandValidator()
        {
            RuleFor(patrticipation => patrticipation.PartialTimeRation)
                .GreaterThan(0);

            RuleFor(patrticipation => patrticipation.Role)
                .NotEmpty()
                .MinimumLength(5);

        }
    }
}
