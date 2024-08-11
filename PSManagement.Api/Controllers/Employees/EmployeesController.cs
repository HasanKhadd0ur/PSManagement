using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PSManagement.Api.Controllers.ApiBase;
using PSManagement.Application.Contracts.Providers;
using PSManagement.Application.Contracts.SyncData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSManagement.Api.Controllers.Employees
{
    [Route("api/[controller]")]
    public class EmployeesController : APIController
    {
        private readonly ISyncEmployeesService _syncEmployeesService;
        private readonly IEmployeesProvider _employeesProvider;
        public EmployeesController(ISyncEmployeesService syncEmployeesService)
        {
            _syncEmployeesService = syncEmployeesService;
        }


        [HttpPost("SyncEmployees")]
        public async Task<IActionResult> Post()
        {

            SyncResponse response = await _syncEmployeesService.SyncEmployees(_employeesProvider);
            return Ok(response);

        }
    }
}
