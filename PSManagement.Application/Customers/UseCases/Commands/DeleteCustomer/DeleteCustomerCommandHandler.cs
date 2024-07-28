using FluentResults;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.DomainErrors;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.DeleteCustomer
{
    public class DeleteCustomerCommandHandler : ICommandHandler<DeleteCustomerCommand, Result>
    {
        private readonly ICustomersRepository _customersRepository;

        public DeleteCustomerCommandHandler(ICustomersRepository customersRepository)
        {
            _customersRepository = customersRepository;
        }

        public async Task<Result> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customersRepository.GetByIdAsync(request.CustomerId);
            if (customer is null)
            {

                return Result.Fail(CustomerErrors.InvalidEntryError);
            }

            await _customersRepository.DeleteAsync(customer);
            
            return Result.Ok();
        }
    }
}
