namespace ConstructionManagementAssistant.Core.Mapping;

public static class TaskProfile
{
    public static Expression<Func<Entites.Task, GetTaskDto>> ToGetTaskDto()
    {
        return task => new GetTaskDto
        {
            Id = task.Id,
            StageId = task.StageId,
            Name = task.Name,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            IsCompleted = task.IsCompleted
        };
    }


    public static Expression<Func<Entites.Task, GetTaskDetailsDto>> ToGetTaskDetailsDto()
    {
        return task => new GetTaskDetailsDto
        {
            Id = task.Id,
            StageId = task.StageId,
            Name = task.Name,
            Description = task.Description,
            StartDate = task.StartDate,
            EndDate = task.EndDate,
            IsCompleted = task.IsCompleted,
            Workers = task.TaskAssignments.Where(x => x.TaskId == task.Id).Select(x => new WorkerAssignmentDto
            {
                Id = x.Worker.Id,
                FullName = x.Worker.GetFullName(),
                AssignmentDate = x.AssignedDate

            }).ToList()
        };
    }

    public static Entites.Task ToTask(this AddTaskDto addTaskDto)
    {
        return new Entites.Task
        {
            StageId = addTaskDto.StageId,
            Name = addTaskDto.Name,
            Description = addTaskDto.Description,
            StartDate = addTaskDto.StartDate,
            EndDate = addTaskDto.EndDate,
            CreatedDate = DateTime.Now
        };
    }

    public static void UpdateTask(this Entites.Task task, UpdateTaskDto updateTaskDto)
    {
        task.Name = updateTaskDto.Name;
        task.Description = updateTaskDto.Description;
        //task.StartDate = updateTaskDto.StartDate;
        //task.EndDate = updateTaskDto.EndDate;
        task.ModifiedDate = DateTime.Now;
    }
}
