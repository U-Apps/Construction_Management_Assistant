
namespace ConstructionManagementAssistant.EF.Repositories;

public class StageRepository : BaseRepository<Stage>, IStageRepository
{
    private readonly ILogger<StageRepository> _logger;
    private readonly AppDbContext _context;

    public StageRepository(AppDbContext context, ILogger<StageRepository> logger) : base(context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<BaseResponse<string>> AddStageAsync(AddStageDto stageDto)
    {
        try
        {
            _logger.LogInformation("Adding a new stage: {StageName}", stageDto.Name);
            if (!await IsStageNameUniqueAsync(stageDto.Name, stageDto.ProjectId))
            {
                _logger.LogWarning("Stage name is not unique: {StageName}", stageDto.Name);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "يوجد مرحلة بنفس الاسم"
                };
            }

            var newStage = stageDto.ToStage();
            await AddAsync(newStage);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Stage added successfully: {StageName}", stageDto.Name);
            return new BaseResponse<string>
            {
                Success = true,
                Message = "Stage added successfully."
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a stage: {StageName}", stageDto.Name);
            throw;
        }
        ;
    }

    public async Task<BaseResponse<string>> DeleteStageAsync(int id)
    {
        var stage = await GetByIdAsync(id);
        if (stage == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المرحلة غير موجوده"
            };
        }

        Delete(stage);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف المرحلة بنجاح"
        };
    }

    public async Task<GetStageDto> GetStageByIdAsync(int Id)
    {
        return await FindWithSelectionAsync(
        selector: StageProfile.ToGetStageDto(),
        criteria: x => x.Id == Id);
    }

    public async Task<PagedResult<GetAllStagesDto>> GetStagesByProjectIdAsync(int projectId, string searchItem, DateOnly? startDateFilter, DateOnly? endDateFilter, int pageNumber = 1, int pageSize = 10)
    {

        Expression<Func<Stage, bool>> filter = s => s.ProjectId == projectId;
        if (!string.IsNullOrWhiteSpace(searchItem))
        {
            filter = filter.AndAlso(s => s.Name.Contains(searchItem) || (s.Description ?? "").Contains(searchItem));
        }
        if (startDateFilter.HasValue && endDateFilter.HasValue)
        {
            if (startDateFilter.Value > endDateFilter.Value)
            {
                return new PagedResult<GetAllStagesDto> { Items = null };
            }
        }
        if (startDateFilter.HasValue)
        {
            filter = filter.AndAlso(s => s.StartDate >= startDateFilter.Value);
        }
        if (endDateFilter.HasValue)
        {
            filter = filter.AndAlso(s => s.EndDate <= endDateFilter.Value);
        }
        var pagedResult = await GetPagedDataWithSelectionAsync(
            orderBy: s => s.Name,
            selector: StageProfile.ToGetAllStagesDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize);

        return pagedResult;
    }

    public async Task<BaseResponse<string>> UpdateStageAsync(UpdateStageDto stageDto)
    {
        var stage = await GetByIdAsync(stageDto.Id);
        if (stage == null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المرحلة غير موجوده"
            };
        }

        if (!await IsStageNameUniqueAsync(stageDto.Name, stageDto.ProjectId))
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "يوجد مرحلة بنفس الاسم"
            };
        }

        stage.UpdateStage(stageDto);
        Update(stage);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المرحلة بنجاح"
        };
    }

    private async Task<bool> IsStageNameUniqueAsync(string name, int projectId)
    {
        return !await AnyAsync(s => s.Name == name && s.ProjectId == projectId);
    }
}
