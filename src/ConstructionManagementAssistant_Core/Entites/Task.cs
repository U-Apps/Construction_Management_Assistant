namespace ConstructionManagementAssistant.Core.Entites
{
    public class Task : IEntity
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? ModifiedDate { get; set; }
        public Stage Stage { get; set; }

        public ICollection<TaskAssignment> TaskAssignments = [];
    }
}
