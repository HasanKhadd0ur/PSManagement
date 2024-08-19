using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.CreateCustomer
{
    public class CreateCustomerCommandValidator :  AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerCommandValidator()
        {
            RuleFor(x => x.CustomerName)
                .NotEmpty()
                .MinimumLength(5);
            RuleFor(x => x.Email)
                .EmailAddress();
        }
    }
}
