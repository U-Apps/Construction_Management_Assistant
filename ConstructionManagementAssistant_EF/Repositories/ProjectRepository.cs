

namespace ConstructionManagementAssistant_EF.Repositories;

public class ProjectRepository(AppDbContext _context) : BaseRepository<Project>(_context), IProjectRepository
{
    public async Task<GetProjectsDto> GetProjectById(int id)
    {
        return await FindWithSelectionAsync(
            selector: ProjectProfile.ToGetProjectDto(),
            criteria: x => x.Id == id);
    }

   
}
