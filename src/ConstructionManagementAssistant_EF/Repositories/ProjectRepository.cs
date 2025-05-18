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
        var project = await FindWithSelectionAsync(
            selector: ProjectProfile.ToProjectDetails(),
            criteria: x => x.Id == id);

        if (project == null)
        {
            _logger.LogWarning("project with ID: {Id} not found", id);
            return null;
        }

        return project;
    }



    public async Task<List<ProjectNameDto>> GetAllProjectNames()
    {
        var pagedResult = await GetAllDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: ProjectProfile.ToGetProjectNameDto());

        return pagedResult;
    }

    public async Task<PagedResult<GetProjectsDto>> GetAllProjects(
        int pageNumber = 1,
        int pageSize = 10,
        ProjectStatus? status = null,
        string? searchTerm = null)
    {
        Expression<Func<Project, bool>> filter = x => true;

        if (status.HasValue)
        {
            filter = filter.AndAlso(p => p.Status == status.Value);
        }

        if (!string.IsNullOrEmpty(searchTerm))
        {
            filter = filter.AndAlso(p =>
                p.Client.FullName.Contains(searchTerm) ||
                p.SiteEngineer.GetFullName().Contains(searchTerm));
        }

        var pagedResult = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: ProjectProfile.ToGetProjectDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize);

        return pagedResult;
    }


    public async Task<BaseResponse<string>> AddProjectAsync(AddProjectDto addProjectDto)
    {
        try
        {
            // Validate ClientId
            var clientExists = await _context.Clients.AnyAsync(c => c.Id == addProjectDto.ClientId);
            if (!clientExists)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "معرف العميل غير صالح"
                };
            }

            // Validate SiteEngineerId (if provided)
            if (addProjectDto.SiteEngineerId.HasValue)
            {
                var siteEngineerExists = await _context.SiteEngineers.AnyAsync(se => se.Id == addProjectDto.SiteEngineerId.Value);
                if (!siteEngineerExists)
                {
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "معرف المهندس الموقعي غير صالح"
                    };
                }
            }

            // Log the addition of a new project
            _logger.LogInformation("Adding a new project: {ProjectName}", addProjectDto.ProjectName);

            // Convert DTO to Project entity
            var newProject = addProjectDto.ToProject();

            // Add the project to the database
            await AddAsync(newProject);
            await _context.SaveChangesAsync();

            // Log success
            _logger.LogInformation("Project added successfully: {ProjectName}", addProjectDto.ProjectName);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم إضافة المشروع بنجاح"
            };
        }
        catch (Exception ex)
        {
            // Log the error
            _logger.LogError(ex, "Error occurred while adding a project: {ProjectName}", addProjectDto.ProjectName);
            throw;
        }
    }


    public async Task<BaseResponse<string>> UpdateProjectAsync(UpdateProjectDto updateProjectDto)
    {
        var project = await GetByIdAsync(updateProjectDto.Id);
        if (project is null)
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };

        project.UpdateProject(updateProjectDto);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم تحديث المشروع بنجاح"
        };
    }

    public async Task<BaseResponse<string>> DeleteProjectAsync(int id)
    {
        var project = await GetByIdAsync(id);
        if (project is null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = "المشروع غير موجود"
            };
        }

        Delete(project);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم حذف المشروع بنجاح"
        };
    }

}

