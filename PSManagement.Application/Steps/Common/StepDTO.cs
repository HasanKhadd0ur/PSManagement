using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Application.Projects.Common
{
    public class StepDTO
    {
        public int Id { get; set; }
        public StepInfo StepInfo { get; set; }
        public int CurrentCompletionRatio { get; set; }
        public int Weight { get; set; }
        public int ProjectId { get; set; }
    }
}