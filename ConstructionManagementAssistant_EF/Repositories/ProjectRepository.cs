

namespace ConstructionManagementAssistant_EF.Repositories;

public class ProjectRepository(AppDbContext _context) : BaseRepository<Project>(_context), IProjectRepository
{
    public async Task<GetProjectsDto> GetProjectById(int id)
    {
        return await FindWithSelectionAsync(
            selector: ProjectProfile.ToGetProjectDto(),
            criteria: x => x.Id == id);
    }

    public async Task<PagedResult<GetProjectsDto>> GetAllProjects(
        int pageNumber = 1,
        int pageSize = 10,
        string? searchTerm = null)
    {
        Expression<Func<Project, bool>> filter = x => true;

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

        var newProject = addProjectDto.ToProject();
        await AddAsync(newProject);
        await _context.SaveChangesAsync();

        return new BaseResponse<string>
        {
            Success = true,
            Message = "تم إضافة المشروع بنجاح"
        };
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

}
