namespace PSManagement.Infrastructure.Settings
{
    public class EmployeesSyncJobSettings
    {
        public const string SectionName = "EmpoyeesSyncJobSettings";
        public int SyncIntervalInMinutes { get; set; }
    }
}
