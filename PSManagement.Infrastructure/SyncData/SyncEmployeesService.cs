using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using PSManagement.Infrastructure.Settings;
using PSManagement.Application.Contracts.SyncData;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Domain.Employees.Repositories;
using PSManagement.Domain.Employees.Entities;
using PSManagement.SharedKernel.Specification;
using PSManagement.Domain.Employees.Specification;

namespace PSManagement.Infrastructure.BackgroundServcies
{
    public class SyncEmployeesService : ISyncEmployeesService
    {

        private readonly IEmployeesRepository _employeesRepository;
        private readonly IEmployeesProvider _employeesProviders;
        private readonly BaseSpecification<Employee> _specification;
        private readonly IDateTimeProvider _timeProvider;
        

        public SyncEmployeesService(
            IEmployeesRepository employeesRepository,
            IEmployeesProvider employeesProviders,
            IDateTimeProvider timeProvider
            )
        {
            _employeesRepository = employeesRepository;
            _employeesProviders = employeesProviders;
            _specification = new EmployeesSpecification();
            _timeProvider = timeProvider;
        }

        public async Task<SyncResponse> SyncEmployees(IEmployeesProvider employeesProvider)
        {
            IEnumerable<Employee> NewestEmployees = await _employeesProviders.FetchEmployees();
            int count = 0;
            
            foreach (Employee employee in NewestEmployees) {
                _specification.Criteria = empl => empl.HIASTId == employee.HIASTId;
                Employee emp = _employeesRepository.ListAsync(_specification).Result.FirstOrDefault();
                if (emp is null) {
                    await _employeesRepository.AddAsync(employee);
                    count++;
                }


            }

            return new(count,_timeProvider.UtcNow);
        }





    }
}
