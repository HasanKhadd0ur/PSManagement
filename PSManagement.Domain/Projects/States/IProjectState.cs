namespace PSManagement.Domain.Projects.Entities
{
    public interface IProjectState
    {
        void Complete(Project project);
        void Plan(Project project);
        void Approve(Project project);
        void Cancle(Project project);
        void Propose(Project project);
        string StateName { get; }
    }

}
