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
using System.Linq;
namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeesByFilter
{
    public class GetEmployeesByFilterQueryHandler : IQueryHandler<GetEmployeesByFilterQuery, Result<IEnumerable<EmployeeDTO>>>
    {
        private readonly IEmployeesRepository _employeesRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<Employee> _specification;

        public GetEmployeesByFilterQueryHandler(
           IEmployeesRepository employeesRepository,
            IMapper mapper)
        {
            _employeesRepository = employeesRepository;
            _mapper = mapper;
            _specification = new EmployeesSpecification();
        }

        public async Task<Result<IEnumerable<EmployeeDTO>>> Handle(GetEmployeesByFilterQuery request, CancellationToken cancellationToken)
        {
            _specification.ApplyOptionalPagination(request.PageSize, request.PageNumber);

            _specification.AddInclude(e=>e.Department);
            _specification.AddInclude(e => e.User);

            IEnumerable<Employee> employees =await _employeesRepository.ListAsync(_specification);
            if (!string.IsNullOrEmpty(request.DepartmentName))
            {
                employees = employees.Where(e => e.Department.Name.ToLower().Contains(request.DepartmentName.Trim().ToLower()));
            }
            if (!string.IsNullOrEmpty(request.EmployeeFirstName))
            {
                employees = employees.Where(e => e.PersonalInfo.FirstName.ToLower().Contains( request.EmployeeFirstName.Trim().ToLower()));
            }

            if (request.HiastId.HasValue)
            {
                employees = employees.Where(e => e.HIASTId== request.HiastId);
            }

            if (!string.IsNullOrEmpty(request.WorkType))
            {
                employees = employees.Where(e => e.WorkInfo.WorkType.ToLower().Contains(request.WorkType.ToLower().Trim()));
            }
            if (!string.IsNullOrEmpty(request.Email))
            {
                employees = employees.Where(e => e.User.Email.ToLower().Contains(request.Email.ToLower().Trim()));
            }

            return Result.Success(_mapper.Map<IEnumerable<EmployeeDTO>>(employees));
        }
    }

}
