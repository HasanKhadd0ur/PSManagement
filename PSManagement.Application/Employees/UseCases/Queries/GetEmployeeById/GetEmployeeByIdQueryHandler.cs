using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Specification;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Specification;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IQueryHandler<GetEmployeeByIdQuery, Result<EmployeeDTO>>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Employee> _specification;

        public GetEmployeeByIdQueryHandler(
            IEmployeesRepository employeesRepository,
            IMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
            _specification = new EmployeesSpecification();
        }

        public async Task<Result<EmployeeDTO>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            _specification.AddInclude(e => e.Department);
            _specification.AddInclude(e => e.User);

            return Result.Success(_mapper.Map<EmployeeDTO>(await _employeesRepository.GetByIdAsync(request.EmployeeId,_specification)));
        }
    }

}
