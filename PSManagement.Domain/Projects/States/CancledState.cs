namespace PSManagement.Domain.Projects.Entities
{
    public class CancledState : IProjectState
    {
        public string StateName => "CancledState";

        public void Approve(Project project)
        {

        }

        public void Cancle(Project project)
        {
        
        }

        public void Complete(Project project)
        {
        
        }

        public void Plan(Project project)
        {
        
        }

        public void Propose(Project project)
        {
        
        }
    }
}
