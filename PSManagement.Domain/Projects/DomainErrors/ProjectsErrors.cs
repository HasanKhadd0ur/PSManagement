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
        public static DomainError InvalidEntryError { get; } = new DomainError("Invalid Project Entry.", new DomainError("Invalid Project Data"));

    }
}
