namespace PSManagement.Domain.Projects.Entities
{
    public class InPlanState : IProjectState
    {
        public string StateName => "InPlan";

        public void Approve(Project project)
        {
            project.SetState(new InProgressState());
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

        }

        public void Propose(Project project)
        {

        }
    }
}
