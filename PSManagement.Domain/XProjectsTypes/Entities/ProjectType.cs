using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.ProjectTypes.Entities
{
    public class ProjectType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int WorkerCount { get; set; }
        public ICollection<Project> Projects { get; set; }

    }
}
