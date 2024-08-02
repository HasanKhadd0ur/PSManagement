using PSManagement.SharedKernel.Aggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.ProjectTypes.Aggregate
{
    public class ProjectType : IAggregateRoot
    {
        public String TypeName { get; set; }
        public String Description { get; set; }
        public int WorkerCount { get; set; }
    }
}
