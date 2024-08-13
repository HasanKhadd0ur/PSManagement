using PSManagement.Domain.Projects.ValueObjects;

namespace PSManagement.Contracts.Projects.Response
{
    public class StepResponse
    {
        public int Id { get; set; }
        public StepInfo StepInfo { get; set; }
        public int CurrentCompletionRatio { get; set; }
        public int Weight { get; set; }
        public int ProjectId { get; set; }
    }
}