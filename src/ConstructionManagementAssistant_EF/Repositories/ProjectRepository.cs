namespace ConstructionManagementAssistant.EF.Repositories;

public class ProjectRepository : BaseRepository<Project>, IProjectRepository
{
    private readonly ILogger<ProjectRepository> _logger;
    private readonly AppDbContext _context;

    public ProjectRepository(AppDbContext context, ILogger<ProjectRepository> logger) : base(context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<ProjectDetailsDto?> GetProjectById(int id)
    {
        _logger.LogInformation("Getting project by ID: {Id}", id);

        var project = await FindWithSelectionAsync(
            selector: ProjectProfile.ToProjectDetails(),
            criteria: x => x.Id == id);

        if (project == null)
        {
            _logger.LogWarning("Project with ID: {Id} not found", id);
            return null;
        }

        _logger.LogInformation("Project with ID: {Id} retrieved successfully", id);
        return project;
    }

    public async Task<List<ProjectNameDto>> GetAllProjectNames(string userId)
    {
        _logger.LogInformation("Getting all project names for userId: {UserId}", userId);

        var pagedResult = await GetAllDataWithSelectionAsync(
            orderBy: x => x.Name,
            criteria: x => x.Client.UserId == int.Parse(userId) && (x.Status != ProjectStatus.Cancelled || x.Status != ProjectStatus.Pending),
            selector: ProjectProfile.ToGetProjectNameDto());

        _logger.LogInformation("Retrieved {Count} project names for userId: {UserId}", pagedResult.Count, userId);
        return pagedResult;
    }

    public async Task<PagedResult<GetProjectsDto>> GetAllProjects(
        string userId,
        int pageNumber = 1,
        int pageSize = 10,
        ProjectStatus? status = null,
        string? searchTerm = null)
    {
        _logger.LogInformation("Getting all projects for userId: {UserId}, page: {PageNumber}, size: {PageSize}, status: {Status}, search: {SearchTerm}",
            userId, pageNumber, pageSize, status, searchTerm);

        Expression<Func<Project, bool>> filter = x => true;

        filter = filter.AndAlso(x => x.Client.UserId == int.Parse(userId));

        if (status.HasValue)
        {
            filter = filter.AndAlso(p => p.Status == status.Value);
        }

        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = filter.AndAlso(p =>
                p.Client.FullName.Contains(searchTerm) ||
                p.SiteEngineer.Name.Contains(searchTerm));
        }

        var pagedResult = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: ProjectProfile.ToGetProjectDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize);

        _logger.LogInformation("Retrieved {Count} projects for userId: {UserId}", pagedResult.Items.Count, userId);
        return pagedResult;
    }

    public async Task<BaseResponse<string>> AddProjectAsync(AddProjectDto addProjectDto)
    {
        try
        {
            _logger.LogInformation("Adding a new project: {ProjectName}", addProjectDto.ProjectName);

            // Validate ClientId
            var clientExists = await _context.Clients.AnyAsync(c => c.Id == addProjectDto.ClientId);
            if (!clientExists)
            {
                _logger.LogWarning("ClientId {ClientId} not found when adding project: {ProjectName}", addProjectDto.ClientId, addProjectDto.ProjectName);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "معرف العميل غير صالح"
                };
            }

            // Validate SiteEngineerId (if provided)
            if (addProjectDto.SiteEngineerId.HasValue)
            {
                var siteEngineerExists = await _context.Users.AnyAsync(se => se.Id == addProjectDto.SiteEngineerId.Value);
                if (!siteEngineerExists)
                {
                    _logger.LogWarning("SiteEngineerId {SiteEngineerId} not found when adding project: {ProjectName}", addProjectDto.SiteEngineerId, addProjectDto.ProjectName);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "معرف المهندس الموقعي غير صالح"
                    };
                }
            }

            // Convert DTO to Project entity
            var newProject = addProjectDto.ToProject();

            // Add the project to the database
            await AddAsync(newProject);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Project added successfully: {ProjectName}", addProjectDto.ProjectName);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم إضافة المشروع بنجاح"
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while adding a project: {ProjectName}", addProjectDto.ProjectName);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UpdateProjectAsync(UpdateProjectDto updateProjectDto)
    {
        _logger.LogInformation("Updating project with ID: {Id}", updateProjectDto.Id);

        var project = await GetByIdAsync(updateProjectDto.Id);
        if (project is null)
        {
            _logger.LogWarning("Project with ID: {Id} not found for update", updateProjectDto.Id);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };
        }

        project.UpdateProject(updateProjectDto);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Project with ID: {Id} updated successfully", updateProjectDto.Id);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المشروع بنجاح"
        };
    }

    public async Task<BaseResponse<string>> DeleteProjectAsync(int id)
    {
        _logger.LogInformation("Deleting project with ID: {Id}", id);

        var project = await GetByIdAsync(id);
        if (project is null)
        {
            _logger.LogWarning("Project with ID: {Id} not found for deletion", id);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };
        }

        Delete(project);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Project with ID: {Id} deleted successfully", id);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف المشروع بنجاح"
        };
    }

    public async Task<BaseResponse<string>> CancelProjectAsync(int projectId, string? cancelationReason)
    {
        _logger.LogInformation("Cancelling project with ID: {Id}", projectId);

        var project = await GetByIdAsync(projectId);
        if (project is null)
        {
            _logger.LogWarning("Project with ID: {Id} not found for cancellation", projectId);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };
        }

        if (project.Status == ProjectStatus.Completed)
        {
            _logger.LogWarning("Cannot cancel completed project with ID: {Id}", projectId);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "لا يمكن إلغاء مشروع مكتمل"
            };
        }

        project.Status = ProjectStatus.Cancelled;
        project.CancelationDate = DateOnly.FromDateTime(DateTime.Now);
        project.CancelationReason = cancelationReason;

        await _context.SaveChangesAsync();

        _logger.LogInformation("Project with ID: {Id} cancelled successfully", projectId);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم ألغاء المشروع بنجاح"
        };
    }

    public async Task<BaseResponse<string>> PendProjectAsync(int projectId)
    {
        _logger.LogInformation("Pending project with ID: {Id}", projectId);

        var project = await GetByIdAsync(projectId);
        if (project is null)
        {
            _logger.LogWarning("Project with ID: {Id} not found for pending", projectId);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };
        }

        if (project.Status == ProjectStatus.Completed)
        {
            _logger.LogWarning("Cannot pend completed project with ID: {Id}", projectId);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "لا يمكن تعليق مشروع مكتمل"
            };
        }

        project.Status = ProjectStatus.Pending;
        await _context.SaveChangesAsync();

        _logger.LogInformation("Project with ID: {Id} set to pending successfully", projectId);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تعليق المشروع بنجاح"
        };
    }

    public async Task<BaseResponse<string>> ActivatePendingProjectAsync(int projectId)
    {
        _logger.LogInformation("Activating pending project with ID: {Id}", projectId);

        var project = await GetByIdAsync(projectId);
        if (project is null)
        {
            _logger.LogWarning("Project with ID: {Id} not found for activation", projectId);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };
        }

        if (project.Status != ProjectStatus.Pending)
        {
            _logger.LogWarning("Project with ID: {Id} is not pending and cannot be activated", projectId);
            return new BaseResponse<string>
            {
                Success = false,
                Message = "يمكن فقط تفعيل المشاريع المعلقة"
            };
        }

        project.Status = ProjectStatus.Active;
        await _context.SaveChangesAsync();

        _logger.LogInformation("Project with ID: {Id} activated successfully", projectId);

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تفعيل المشروع بنجاح"
        };
    }
}
