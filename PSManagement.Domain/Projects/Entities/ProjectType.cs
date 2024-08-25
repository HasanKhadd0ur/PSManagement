using PSManagement.SharedKernel.Entities;
using System.Collections.Generic;

namespace PSManagement.Domain.Projects.Entities
{
    public class ProjectType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int ExpectedEffort { get; set; }
        public ICollection<Project> Projects { get; set; }

    }

}
