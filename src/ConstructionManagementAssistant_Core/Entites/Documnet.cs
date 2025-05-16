namespace ConstructionManagementAssistant.Core.Entites
{
    public class Documnet : ISoftDeletable
    {
        #region Properties
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string FileType { get; set; }
        public string? Path { get; set; }
        public int? TaskId { get; set; }
        public int ProjectId { get; set; }
        public int ClassificationId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        //public string UploadedBy { get; set; }  // refernces Users table
        public bool IsDeleted { get; set;}
        public DateTime? DeletedDate { get; set; }

        #endregion

        #region Navigation Properties
        public DocumentClassification? Classification { get; set; }
        public ProjectTask? Task { get; set; }
        public Project Project { get; set; }
        #endregion

    }
}
