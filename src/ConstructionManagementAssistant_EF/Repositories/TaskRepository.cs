namespace ConstructionManagementAssistant.EF.Repositories;

public class TaskRepository : BaseRepository<ConstructionManagementAssistant.Core.Entites.ProjectTask>, ITaskRepository
{
    private readonly ILogger<TaskRepository> _logger;
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context, ILogger<TaskRepository> logger) : base(context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<GetTaskDetailsDto?> GetTaskById(int id)
    {
        _logger.LogInformation("Fetching task with ID: {Id}", id);
        try
        {
            var task = await FindWithSelectionAsync(
                selector: TaskProfile.ToGetTaskDetailsDto(),
                criteria: x => x.Id == id);

            if (task == null)
            {
                _logger.LogWarning("Task with ID: {Id} not found", id);
                return null;
            }

            _logger.LogInformation("Task with ID: {Id} fetched successfully", id);
            return task;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching task with ID: {Id}", id);
            throw;
        }
    }

    public async Task<PagedResult<GetTaskDto>> GetAllTasks(
        int stageId,
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
    {
        _logger.LogInformation("Fetching tasks for stageId: {StageId}, page: {PageNumber}, size: {PageSize}, search: {SearchTerm}", stageId, pageNumber, pageSize, searchTerm);
        try
        {
            Expression<Func<ConstructionManagementAssistant.Core.Entites.ProjectTask, bool>> filter = x => x.StageId == stageId;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter = filter.AndAlso(t =>
                    t.Name.Contains(searchTerm) ||
                    t.Description.Contains(searchTerm));
            }

            var pagedResult = await GetPagedDataWithSelectionAsync(
                orderBy: x => x.StartDate,
                selector: TaskProfile.ToGetTaskDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize);

            _logger.LogInformation("Fetched {Count} tasks for stageId: {StageId}", pagedResult.Items.Count, stageId);

            return pagedResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching tasks for stageId: {StageId}", stageId);
            throw;
        }
    }

    public async Task<BaseResponse<string>> AddTaskAsync(AddTaskDto taskDto)
    {
        _logger.LogInformation("Adding a new task: {TaskName} to stage {StageId}", taskDto.Name, taskDto.StageId);
        try
        {
            var stage = await _context.Stages.FindAsync(taskDto.StageId);
            var project = await _context.Projects.FindAsync(stage.ProjectId);

            if (project is null)
            {
                _logger.LogWarning("Project not found for stageId: {StageId}", taskDto.StageId);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير موجود"
                };
            }

            if (project.Status == ProjectStatus.Cancelled || project.Status == ProjectStatus.Pending)
            {
                _logger.LogWarning("Project {ProjectId} is not active (status: {Status})", project.Id, project.Status);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير فعال"
                };
            }

            if (!await IsTaskNameUniqueAsync(taskDto.Name, taskDto.StageId))
            {
                _logger.LogWarning("Task name is not unique: {TaskName} for stage {StageId}", taskDto.Name, taskDto.StageId);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "يوجد مهمة بنفس الاسم"
                };
            }

            var newTask = taskDto.ToTask();
            await AddAsync(newTask);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task added successfully: {TaskName}", taskDto.Name);
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تمت إضافة المهمة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a task: {TaskName}", taskDto.Name);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UpdateTaskAsync(UpdateTaskDto taskDto)
    {
        _logger.LogInformation("Updating task with ID: {Id}", taskDto.Id);
        try
        {
            var task = await GetByIdAsync(taskDto.Id);
            if (task is null)
            {
                _logger.LogWarning("Task with ID: {Id} not found for update", taskDto.Id);
                return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };
            }

            // Uncomment and log if you want to check for unique name on update
            //if (!await IsTaskNameUniqueAsync(taskDto.Name, taskDto.StageId))
            //{
            //    _logger.LogWarning("Task name is not unique: {TaskName} for stage {StageId}", taskDto.Name, taskDto.StageId);
            //    return new BaseResponse<string>
            //    {
            //        Success = false,
            //        Message = "يوجد مهمة بنفس الاسم"
            //    };
            //}

            task.UpdateTask(taskDto);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task with ID: {Id} updated successfully", taskDto.Id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث المهمة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating task with ID: {Id}", taskDto.Id);
            throw;
        }
    }

    public async Task<BaseResponse<string>> DeleteTaskAsync(int id)
    {
        _logger.LogInformation("Deleting task with ID: {Id}", id);
        try
        {
            var task = await GetByIdAsync(id);
            if (task is null)
            {
                _logger.LogWarning("Task with ID: {Id} not found for delete", id);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المهمة غير موجودة"
                };
            }

            Delete(task);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task with ID: {Id} deleted successfully", id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف المهمة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting task with ID: {Id}", id);
            throw;
        }
    }

    private async Task<bool> IsTaskNameUniqueAsync(string name, int stageId)
    {
        return !await AnyAsync(s => s.Name == name && s.StageId == stageId);
    }

    public async Task<BaseResponse<string>> CompleteTaskAsync(int taskId)
    {
        _logger.LogInformation("Completing task with ID: {Id}", taskId);
        try
        {
            var task = await GetByIdAsync(taskId);
            if (task is null)
            {
                _logger.LogWarning("Task with ID: {Id} not found for completion", taskId);
                return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };
            }

            task.IsCompleted = true;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task with ID: {Id} marked as completed", taskId);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث المهمة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error completing task with ID: {Id}", taskId);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UnCheckTaskAsync(int taskId)
    {
        _logger.LogInformation("Unchecking (marking as not completed) task with ID: {Id}", taskId);
        try
        {
            var task = await GetByIdAsync(taskId);
            if (task is null)
            {
                _logger.LogWarning("Task with ID: {Id} not found for uncheck", taskId);
                return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };
            }

            task.IsCompleted = false;
            await _context.SaveChangesAsync();

            _logger.LogInformation("Task with ID: {Id} marked as not completed", taskId);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث المهمة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error unchecking task with ID: {Id}", taskId);
            throw;
        }
    }

    public async Task<IEnumerable<GetUpcomingTaskDto>> GetUpcomingTasksAsync(int daysAhead = 7)
    {
        _logger.LogInformation("Fetching upcoming tasks for the next {DaysAhead} days", daysAhead);
        try
        {
            var today = DateOnly.FromDateTime(DateTime.Now);
            var endDate = today.AddDays(daysAhead);

            var upcomingTasks = await _context.Tasks
                .Include(t => t.Stage)
                    .ThenInclude(s => s.Project)
                .Where(t => !t.IsCompleted &&
                           t.ExpectedEndDate.HasValue &&
                           t.ExpectedEndDate.Value >= today &&
                           t.ExpectedEndDate.Value <= endDate)
                .Select(TaskProfile.ToGetUpcomingTaskDto())
                .OrderBy(t => t.ExpectedEndDate)
                .ToListAsync();

            _logger.LogInformation("Fetched {Count} upcoming tasks for the next {DaysAhead} days", upcomingTasks.Count, daysAhead);

            return upcomingTasks;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching upcoming tasks for the next {DaysAhead} days", daysAhead);
            throw;
        }
    }
}
