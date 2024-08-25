using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Queries.GetAvailableEmployees
{
    public class GetAvailableEmployeesQueryHandler : IQueryHandler<GetAvailableEmployeesQuery, Result<IEnumerable<EmployeeDTO>>>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Employee> _specification;

        public GetAvailableEmployeesQueryHandler(
            IEmployeesRepository employeesRepository,
            IMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
            _specification = new EmployeesSpecification();
        }

        public async Task<Result<IEnumerable<EmployeeDTO>>> Handle(GetAvailableEmployeesQuery request, CancellationToken cancellationToken)
        {
            _specification.ApplyOptionalPagination(request.PageSize, request.PageNumber);

            _specification.AddInclude(e => e.Department);
            _specification.AddInclude(e => e.User);
        

            return Result.Success(_mapper.Map<IEnumerable<EmployeeDTO>>(await _employeesRepository.ListAsync(_specification)));
        }
    }
}
