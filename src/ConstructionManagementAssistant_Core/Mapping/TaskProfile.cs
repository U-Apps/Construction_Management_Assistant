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
            ExpectedEndDate = task.ExpectedEndDate,
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
            ExpectedEndDate = task.ExpectedEndDate,
            IsCompleted = task.IsCompleted,
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
            ExpectedEndDate = addTaskDto.ExpectedEndDate,
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
