using PSManagement.SharedKernel.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Entities
{
    public class ProjectCompletion :BaseEntity
    {
        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public DateTime CompletionDate { get; set; }
        public String CustomerNotes { get; set; }
        public int CustomerRate { get; set; }
        
    }

}
