using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Projects.Common;
using PSManagement.Domain.Projects;
using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using PSManagement.SharedKernel.Specification;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

namespace PSManagement.Application.Employees.UseCases.Queries.GetEmployeeById
{
    public class GetEmployeeParticipationQueryHandler : IQueryHandler<GetEmployeeParticipationQuery, Result<IEnumerable<EmployeeParticipateDTO>>>
    {
        private readonly IRepository<EmployeeParticipate> _employeesParticipateRepository;
        private readonly IMapper _mapper;
        private readonly BaseSpecification<EmployeeParticipate> _specification;

        public GetEmployeeParticipationQueryHandler(
           IRepository<EmployeeParticipate> employeesParticipateRepository,
            IMapper mapper)
        {
            _employeesParticipateRepository = employeesParticipateRepository;
            _mapper = mapper;
            _specification = new EmployeeParticipateSpecification();
        }

        public async Task<Result<IEnumerable<EmployeeParticipateDTO>>> Handle(GetEmployeeParticipationQuery request, CancellationToken cancellationToken)
        {
            int pageNumber = request.PageNumber.HasValue && request.PageNumber.Value > 0 ? request.PageNumber.Value : 1;
            int pageSize = request.PageSize.HasValue && request.PageSize.Value > 0 && request.PageSize.Value <= 30 ? request.PageSize.Value : 30;
            _specification.ApplyPaging((pageNumber - 1) * pageSize, pageSize);

            _specification.AddInclude(e => e.Project);
            _specification.AddInclude("Employee.Department");

            _specification.AddInclude(e => e.Employee);
            _specification.AddInclude(e => e.Employee.Department);


            IEnumerable<EmployeeParticipate> response = await _employeesParticipateRepository.ListAsync(_specification);

            response =response.Where(e => e.EmployeeId == request.EmployeeId).ToList();

            return Result.Success(_mapper.Map<IEnumerable<EmployeeParticipateDTO>>(response));
        }
    }


}
