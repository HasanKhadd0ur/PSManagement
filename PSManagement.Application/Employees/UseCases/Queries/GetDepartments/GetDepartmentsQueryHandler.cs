using Ardalis.Result;
using AutoMapper;
using PSManagement.Application.Employees.Common;
using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.CQRS.Query;
using PSManagement.SharedKernel.Repositories;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PSManagement.Application.Employees.UseCases.Queries.GetDepartments
{
    public class GetDepartmentsQueryHandler : IQueryHandler<GetDepartmentsQuery, Result<IEnumerable<DepartmentDTO>>>
    {
        private readonly IRepository<Department> _deparmentsRepository;
        private readonly IMapper _mapper;

        public GetDepartmentsQueryHandler(IMapper mapper, IRepository<Department> deparmentsRepository)
        {
            _mapper = mapper;
            _deparmentsRepository = deparmentsRepository;
        }

        public async Task<Result<IEnumerable<DepartmentDTO>>> Handle(GetDepartmentsQuery request, CancellationToken cancellationToken)
        {
            var result = await _deparmentsRepository.ListAsync();

            return Result.Success(_mapper.Map<IEnumerable<DepartmentDTO>>(result));
        }
    }

}

