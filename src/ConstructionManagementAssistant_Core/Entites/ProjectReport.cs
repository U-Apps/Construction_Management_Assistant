namespace ConstructionManagementAssistant.Core.Entites
{
    public class ProjectReport : Documnet
    {
        #region Properties
        public int ProjectId { get; set; }
        #endregion

        #region Navigation Properties
        public Project? Project { get; set; }
        public DocumentClassification classification { get; set; }
        #endregion
    }
}
