namespace ConstructionManagementAssistant.Core.Mapping;

public static class TaskProfile
{
    public static Expression<Func<Entites.ProjectTask, GetTaskDto>> ToGetTaskDto()
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


    public static Expression<Func<Entites.ProjectTask, GetTaskDetailsDto>> ToGetTaskDetailsDto()
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

    public static Expression<Func<Entites.ProjectTask, GetUpcomingTaskDto>> ToGetUpcomingTaskDto()
    {
        return task => new GetUpcomingTaskDto
        {
            Id = task.Id,
            Name = task.Name,
            Description = task.Description,
            StartDate = task.StartDate,
            ExpectedEndDate = task.ExpectedEndDate,
            StageName = task.Stage.Name,
            ProjectName = task.Stage.Project.Name,
            IsCompleted = task.IsCompleted
        };
    }

    public static Entites.ProjectTask ToTask(this AddTaskDto addTaskDto)
    {
        return new Entites.ProjectTask
        {
            StageId = addTaskDto.StageId,
            Name = addTaskDto.Name,
            Description = addTaskDto.Description,
            StartDate = addTaskDto.StartDate,
            ExpectedEndDate = addTaskDto.ExpectedEndDate,
            CreatedDate = DateTime.Now
        };
    }

    public static void UpdateTask(this Entites.ProjectTask task, UpdateTaskDto updateTaskDto)
    {
        task.Name = updateTaskDto.Name;
        task.Description = updateTaskDto.Description;
        //task.StartDate = updateTaskDto.StartDate;
        //task.EndDate = updateTaskDto.EndDate;
        task.ModifiedDate = DateTime.Now;
    }
}
