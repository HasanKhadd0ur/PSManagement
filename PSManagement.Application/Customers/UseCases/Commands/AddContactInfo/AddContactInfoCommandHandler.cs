using Ardalis.Result;
using PSManagement.Domain.Customers.DomainErrors;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.AddContactInfo
{
    public class AddContactInfoCommandHandler : ICommandHandler<AddContactInfoCommand, Result>
    {
        private readonly ICustomersRepository _customersRepository;

        public AddContactInfoCommandHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Result> Handle(AddContactInfoCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customersRepository.GetByIdAsync(request.CustomerId);

            if (customer is null) {

                return Result.Invalid(CustomerErrors.InvalidEntryError);
            }
            
            ContactInfo contact = new (request.ContactValue,request.ContactType);
            customer.AddContactInfo(contact);
            await _customersRepository.UpdateAsync(customer);
            return Result.Success();
        }
    }

}
