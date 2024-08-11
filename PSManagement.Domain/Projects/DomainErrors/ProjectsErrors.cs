using ErrorOr;
using PSManagement.SharedKernel.DomainErrors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.DomainErrors
{
    public class ProjectsErrors
    {
        public static Error InvalidEntryError { get; } = Error.Validation("ProjectError.InvalidEntry.", "Invalid Project Data");

    }
}
