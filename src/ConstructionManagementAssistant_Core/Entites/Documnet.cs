namespace ConstructionManagementAssistant.Core.Entites
{
    public class Documnet : IEntity
    {
        #region Properties
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Path { get; set; }
        public int? TaskId { get; set; }
        public int ProjectId { get; set; }
        public int ClassificationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        #endregion

        #region Navigation Properties
        public DocumentClassification? Classification { get; set; }
        public Task? Task { get; set; }
        public Project Project { get; set; }
        #endregion

    }
}
