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
        _logger.LogInformation("Adding a new stage: {StageName} to project {ProjectId}", stageDto.Name, stageDto.ProjectId);
        try
        {
            var project = await _context.Projects.FindAsync(stageDto.ProjectId);
            if (project is null)
            {
                _logger.LogWarning("Project with ID: {ProjectId} not found when adding stage", stageDto.ProjectId);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير موجود"
                };
            }

            if (project.Status == ProjectStatus.Cancelled || project.Status == ProjectStatus.Pending)
            {
                _logger.LogWarning("Project {ProjectId} is not active (status: {Status})", stageDto.ProjectId, project.Status);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير فعال"
                };
            }

            if (!await IsStageNameUniqueAsync(stageDto.Name, stageDto.ProjectId))
            {
                _logger.LogWarning("Stage name is not unique: {StageName} for project {ProjectId}", stageDto.Name, stageDto.ProjectId);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "يوجد مرحلة بنفس الاسم"
                };
            }

            var newStage = stageDto.ToStage();
            await AddAsync(newStage);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Stage added successfully: {StageName} to project {ProjectId}", stageDto.Name, stageDto.ProjectId);
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
    }

    public async Task<BaseResponse<string>> DeleteStageAsync(int id)
    {
        _logger.LogInformation("Deleting stage with ID: {Id}", id);
        try
        {
            var stage = await GetByIdAsync(id);
            if (stage == null)
            {
                _logger.LogWarning("Stage with ID: {Id} not found for delete", id);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المرحلة غير موجوده"
                };
            }

            Delete(stage);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Stage with ID: {Id} deleted successfully", id);
            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف المرحلة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting stage with ID: {Id}", id);
            throw;
        }
    }

    public async Task<GetStageDetailsDto> GetStageByIdAsync(int Id)
    {
        _logger.LogInformation("Fetching stage details for ID: {Id}", Id);
        try
        {
            var result = await FindWithSelectionAsync(
                selector: StageProfile.ToGetStageDto(),
                criteria: x => x.Id == Id);

            if (result == null)
                _logger.LogWarning("Stage with ID: {Id} not found", Id);
            else
                _logger.LogInformation("Stage with ID: {Id} fetched successfully", Id);

            return result;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching stage details for ID: {Id}", Id);
            throw;
        }
    }

    public async Task<PagedResult<GetStageDto>> GetStagesByProjectIdAsync(int projectId, string searchItem, DateOnly? startDateFilter, DateOnly? endDateFilter, int pageNumber = 1, int pageSize = 10)
    {
        _logger.LogInformation("Fetching stages for projectId: {ProjectId}, search: {SearchItem}, start: {StartDate}, end: {EndDate}, page: {PageNumber}, size: {PageSize}",
            projectId, searchItem, startDateFilter, endDateFilter, pageNumber, pageSize);

        try
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
                    _logger.LogWarning("Start date filter is after end date filter for projectId: {ProjectId}", projectId);
                    return new PagedResult<GetStageDto> { Items = null };
                }
            }
            if (startDateFilter.HasValue)
            {
                filter = filter.AndAlso(s => s.StartDate >= startDateFilter.Value);
            }
            if (endDateFilter.HasValue)
            {
                filter = filter.AndAlso(s => s.ExpectedEndDate <= endDateFilter.Value);
            }
            var pagedResult = await GetPagedDataWithSelectionAsync(
                orderBy: s => s.Name,
                selector: StageProfile.ToGetAllStagesDto(),
                criteria: filter,
                pageNumber: pageNumber,
                pageSize: pageSize);

            _logger.LogInformation("Fetched {Count} stages for projectId: {ProjectId}", pagedResult.Items?.Count ?? 0, projectId);

            return pagedResult;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching stages for projectId: {ProjectId}", projectId);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UpdateStageAsync(UpdateStageDto stageDto)
    {
        _logger.LogInformation("Updating stage with ID: {Id}", stageDto.Id);
        try
        {
            var stage = await GetByIdAsync(stageDto.Id);
            if (stage == null)
            {
                _logger.LogWarning("Stage with ID: {Id} not found for update", stageDto.Id);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المرحلة غير موجوده"
                };
            }

            // Uncomment and log if you want to check for unique name on update
            //if (!await IsStageNameUniqueAsync(stageDto.Name, stageDto.ProjectId))
            //{
            //    _logger.LogWarning("Stage name is not unique: {StageName} for project {ProjectId}", stageDto.Name, stageDto.ProjectId);
            //    return new BaseResponse<string>
            //    {
            //        Success = false,
            //        Message = "يوجد مرحلة بنفس الاسم"
            //    };
            //}

            stage.UpdateStage(stageDto);
            Update(stage);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Stage with ID: {Id} updated successfully", stageDto.Id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث المرحلة بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating stage with ID: {Id}", stageDto.Id);
            throw;
        }
    }

    private async Task<bool> IsStageNameUniqueAsync(string name, int projectId)
    {
        return !await AnyAsync(s => s.Name == name && s.ProjectId == projectId);
    }
}
