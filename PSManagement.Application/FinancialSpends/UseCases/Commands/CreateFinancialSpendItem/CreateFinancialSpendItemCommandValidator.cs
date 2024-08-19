using FluentValidation;

namespace PSManagement.Application.FinancialSpends.UseCases.Commands.CreateFinancialSpendItem
{
    public class CreateFinancialSpendItemCommandValidator : AbstractValidator<CreateFinancialSpendItemCommand>
    {
        public CreateFinancialSpendItemCommandValidator()
        {
            RuleFor(x => x.Description)
                .NotEmpty()
                .MinimumLength(10);
            RuleFor(x => x.ExternalPurchase.Ammount)
                .GreaterThan(0);

            RuleFor(x => x.ExternalPurchase.Currency)
                .NotEmpty();

        }
    }
}
