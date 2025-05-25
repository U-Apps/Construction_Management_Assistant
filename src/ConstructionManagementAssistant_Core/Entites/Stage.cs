

namespace ConstructionManagementAssistant.Core.Entites
{
    public class Stage : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? ExpectedEndDate { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public int ProjectId { get; set; }
        public Project Project { get; set; } = new();

        #region Navigation Properties
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
        #endregion

    }
}
