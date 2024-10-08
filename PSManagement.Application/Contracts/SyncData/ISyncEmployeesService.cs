﻿using PSManagement.Application.Contracts.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Application.Contracts.SyncData
{
    public interface ISyncEmployeesService
    {
        public Task<SyncResponse> SyncEmployees(IEmployeesProvider employeesProvider);
    }
    public record SyncResponse(
        int SyncDataCount,
        DateTime SyncDate
        );
}
