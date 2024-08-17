using Ardalis.Result;
using PSManagement.Domain.Customers.DomainErrors;
using PSManagement.Domain.Customers.Entities;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using PSManagement.SharedKernel.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.RemoveContactInfo
{
    public class RemoveContactInfoCommandHandler : ICommandHandler<RemoveContactInfoCommand, Result>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IRepository<ContactInfo> _contactsRepository;

        public RemoveContactInfoCommandHandler(
            ICustomersRepository customersRepository,
            IRepository<ContactInfo> contactsRepository)
        {
            _customersRepository = customersRepository;
            _contactsRepository = contactsRepository;
        }

        public async Task<Result> Handle(RemoveContactInfoCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customersRepository.GetByIdAsync(request.CustomerId);

            if (customer is null)
            {

                return Result.Invalid(CustomerErrors.InvalidEntryError);
            }

            ContactInfo contact = await _contactsRepository.GetByIdAsync(request.Id);
            
            if (contact is null) {
                return Result.Invalid(CustomerErrors.InvalidEntryError);
            }

            await _contactsRepository.DeleteAsync(contact);
            return Result.Success();
        }
    }

}
