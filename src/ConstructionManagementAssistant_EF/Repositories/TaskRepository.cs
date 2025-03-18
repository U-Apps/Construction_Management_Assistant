namespace ConstructionManagementAssistant.EF.Repositories;

public class TaskRepository(AppDbContext _context) : BaseRepository<ConstructionManagementAssistant.Core.Entites.Task>(_context), ITaskRepository
{
    public async Task<GetTaskDto> GetTaskById(int id)
    {
        return await FindWithSelectionAsync(
            selector: TaskProfile.ToGetTaskDto(),
            criteria: x => x.Id == id);
    }

    public async Task<PagedResult<GetTaskDto>> GetAllTasks(
        int stageId,
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
    {
        Expression<Func<ConstructionManagementAssistant.Core.Entites.Task, bool>> filter = x => x.StageId == stageId;

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
        if (!await IsTaskNameUniqueAsync(taskDto.Name, taskDto.StageId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "يوجد مهمة بنفس الاسم"
            };
        }

        var newTask = taskDto.ToTask();
        await AddAsync(newTask);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تمت إضافة المهمة بنجاح"
        };
    }

    public async Task<BaseResponse<string>> UpdateTaskAsync(UpdateTaskDto taskDto)
    {
        var task = await GetByIdAsync(taskDto.Id);
        if (task is null)
            return new BaseResponse<string> { Success = false, Message = "المهمة غير موجودة" };

        if (!await IsTaskNameUniqueAsync(taskDto.Name, taskDto.StageId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "يوجد مهمة بنفس الاسم"
            };
        }

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
}
