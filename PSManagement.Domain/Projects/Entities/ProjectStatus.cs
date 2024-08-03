using PSManagement.SharedKernel.Entities;

namespace PSManagement.Domain.Projects.Entities
{
    public class ProjectStatus : BaseEntity
    {
        public string Name { get; set; }
        public string Details { get; set; }
        public string Code { get; set; }


    }
}
