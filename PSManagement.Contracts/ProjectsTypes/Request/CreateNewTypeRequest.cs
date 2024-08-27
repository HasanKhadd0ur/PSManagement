using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Contracts.ProjectsTypes.Request
{
    public record CreateNewTypeRequest(
         string TypeName,
         string Description,
         int ExpectedEffort,
         int ExpectedNumberOfWorker
    
     );
    
}
