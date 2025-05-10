namespace ConstructionManagementAssistant.Core.Entites
{
    public class TaskReport : Documnet
    {
        #region Properties
        public int TaskId { get; set; }
        public string? SiteEngineerId { get; set; }
        #endregion
        #region Navigation Properties
        public ReportType ReportType { get; set; }
        public Task? Task { get; set; }

        public SiteEngineer? SiteEngineer { get; set; }
        #endregion
    }
}
