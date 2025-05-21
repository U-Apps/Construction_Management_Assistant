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
        var task = await FindWithSelectionAsync(
            selector: TaskProfile.ToGetTaskDetailsDto(),
            criteria: x => x.Id == id);

        if (task == null)
        {
            _logger.LogWarning("task with ID: {Id} not found", id);
            return null;

        }

        return task;
    }

    public async Task<PagedResult<GetTaskDto>> GetAllTasks(
        int stageId,
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
    {
        Expression<Func<ConstructionManagementAssistant.Core.Entites.ProjectTask, bool>> filter = x => x.StageId == stageId;

        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = filter.AndAlso(t =>
                t.Name.Contains(searchTerm) ||
                t.Description.Contains(searchTerm));
        }



        var pagedResult = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: TaskProfile.ToGetTaskDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize);

        return pagedResult;
    }

    public async Task<BaseResponse<string>> AddTaskAsync(AddTaskDto taskDto)
    {
        try
        {
            var project = await _context.Projects.FirstOrDefaultAsync(x => x.Stages.Select(x => x.Id).Contains(taskDto.StageId));
            if (project is null)
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير موجود"
                };

            if (project.Status == ProjectStatus.Cancelled || project.Status != ProjectStatus.Pending)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير فعال"
                };
            }


            _logger.LogInformation("Adding a new task: {TaskName}", taskDto.Name);
            if (!await IsTaskNameUniqueAsync(taskDto.Name, taskDto.StageId))
            {
                _logger.LogWarning("Task name is not unique: {TaskName}", taskDto.Name);
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
        var task = await GetByIdAsync(taskDto.Id);
        if (task is null)
            return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };

        //if (!await IsTaskNameUniqueAsync(taskDto.Name, taskDto.StageId))
        //{
        //    return new BaseResponse<string>
        //    {
        //        Success = false,
        //        Message = "يوجد مهمة بنفس الاسم"
        //    };
        //}

        task.UpdateTask(taskDto);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المهمة بنجاح"
        };
    }

    public async Task<BaseResponse<string>> DeleteTaskAsync(int id)
    {
        var task = await GetByIdAsync(id);
        if (task is null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المهمة غير موجودة"
            };
        }

        Delete(task);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف المهمة بنجاح"
        };
    }

    private async Task<bool> IsTaskNameUniqueAsync(string name, int stageId)
    {
        return !await AnyAsync(s => s.Name == name && s.StageId == stageId);
    }

    public async Task<BaseResponse<string>> CompleteTaskAsync(int taskId)
    {
        var task = await GetByIdAsync(taskId);
        if (task is null)
            return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };

        task.IsCompleted = true;
        await _context.SaveChangesAsync();
        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المهمة بنجاح"
        };
    }

    public async Task<BaseResponse<string>> UnCheckTaskAsync(int taskId)
    {
        var task = await GetByIdAsync(taskId);
        if (task is null)
            return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };

        task.IsCompleted = false;
        await _context.SaveChangesAsync();
        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المهمة بنجاح"
        };
    }
}
