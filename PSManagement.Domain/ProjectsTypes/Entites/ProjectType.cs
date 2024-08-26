using PSManagement.Domain.Projects.Entities;
using PSManagement.SharedKernel.Entities;
using System.Collections.Generic;

namespace PSManagement.Domain.ProjectsTypes.Entites
{
    public class ProjectType : BaseEntity
    {
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int ExpectedEffort { get; set; }
        public int ExpectedNumberOfWorker { get; set; }
        public ICollection<Project> Projects { get; set; }

    }


}
