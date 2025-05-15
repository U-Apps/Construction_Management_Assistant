namespace ConstructionManagementAssistant.Core.DTOs
{
    public class GetTaskDto
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }


    public class GetTaskDetailsDto
    {
        public int Id { get; set; }
        public int StageId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsCompleted { get; set; }
        public ICollection<WorkerNameDto> Workers { get; set; }

    }


    public class TaskNameDto
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public string Name { get; set; }
    }

    public class AddTaskDto
    {
        public required int StageId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class UpdateTaskDto
    {
        public int Id { get; set; }
        public required int StageId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
