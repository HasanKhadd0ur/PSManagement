using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.Projects.Requests
{
    public record ListAllProjectsRequest(
        int? PageNumber,
        int? PageSize
        ) ;
}
