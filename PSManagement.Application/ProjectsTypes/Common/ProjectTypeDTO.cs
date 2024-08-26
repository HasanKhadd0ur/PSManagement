namespace PSManagement.Application.ProjectsTypes.Common
{
    public class ProjectTypeDTO
    {
        public int Id { get; set; }
        public string TypeName { get; set; }
        public string Description { get; set; }
        public int ExpectedEffort { get; set; }
        public int ExpectedNumberOfWorker { get; set; }
    }

}