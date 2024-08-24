using PSManagement.Domain.Employees.Entities;
using PSManagement.Domain.Projects.ValueObjects;
using PSManagement.Domain.Tracking;
using PSManagement.Domain.Tracking.Entities;
using PSManagement.SharedKernel.Aggregate;
using PSManagement.SharedKernel.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSManagement.Domain.Projects.Entities
{
    public class Step : BaseEntity
    {
        
        public StepInfo StepInfo { get; set; }
        public int CurrentCompletionRatio { get; set; }
        public int Weight { get; set; }

        public int ProjectId { get; set; }
        public Project Project { get; set; }
        public ICollection<StepTrack> StepTracks { get; set; }


        public Step()
        {

        }

        public Step(StepInfo stepInfo, int projectId,int currentCompletionRatio, int weight)
        {
            CurrentCompletionRatio =currentCompletionRatio;
            StepInfo = stepInfo;
            ProjectId = projectId;
            Weight = weight;
        }
    }

}
