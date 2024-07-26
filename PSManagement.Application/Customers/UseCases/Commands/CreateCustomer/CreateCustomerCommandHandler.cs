using FluentResults;
using PSManagement.Domain.Customers.Aggregate;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.SharedKernel.CQRS.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Commands.CreateCustomer
{
    public class CreateCustomerCommandHandler : ICommandHandler<CreateCustomerCommand, Result<int>>
    {
        private readonly ICustomersRepository _customerRepository;
        public CreateCustomerCommandHandler()
        {
                
        }
        public async Task<Result<int>> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {

            Customer customer = new Customer(request.CustomerName ,request.Address);

            await _customerRepository.AddAsync(customer);
            return Result.Ok(customer.Id);
        }
    }
}
