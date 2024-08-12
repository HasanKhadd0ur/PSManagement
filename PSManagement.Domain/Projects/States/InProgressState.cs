namespace PSManagement.Domain.Projects.Entities
{
    public class InProgressState : IProjectState
    {
        public string StateName => "InProgress";

        public void Approve(Project project)
        {

        }

        public void Cancle(Project project)
        {
            project.SetState(new CancledState());
        }

        public void Complete(Project project)
        {
            project.SetState(new CompletedState());
        }

        public void Plan(Project project)
        {
            project.SetState(new InPlanState());
        }

        public void Propose(Project project)
        {

        }
    }
}
