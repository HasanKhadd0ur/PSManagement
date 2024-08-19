using FluentValidation;

namespace PSManagement.Application.Customers.UseCases.Commands.AddContactInfo
{
    public class AddContactInfoCommandValidator : AbstractValidator<AddContactInfoCommand>
    {
        public AddContactInfoCommandValidator()
        {
            RuleFor(x => x.ContactType)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(x => x.ContactValue)
                .MinimumLength(5);

        }
    }

}
