using AutoMapper;
using FluentResults;
using PSManagement.Application.Customers.Common;
using PSManagement.Domain.Customers.Repositories;
using PSManagement.SharedKernel.CQRS.Query;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Customers.UseCases.Queries.ListAllCustomers
{
    public class ListAllCustomersQueryHandler : IQueryHandler<ListAllCustomersQuery, Result<IEnumerable<CustomerDTO>>>
    {
        private readonly ICustomersRepository _customersRepository;
        private readonly IMapper _mapper;
        public ListAllCustomersQueryHandler(ICustomersRepository customersRepository, IMapper mapper)
        {
            _customersRepository = customersRepository;
            _mapper = mapper;
        }

        public async Task<Result<IEnumerable<CustomerDTO>>> Handle(ListAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return  Result.Ok( _mapper.Map<IEnumerable<CustomerDTO>>(await _customersRepository.ListAsync()));
        }
    }

}
