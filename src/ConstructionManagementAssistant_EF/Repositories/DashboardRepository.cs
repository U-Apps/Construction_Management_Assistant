namespace ConstructionManagementAssistant.Core.Repositories;

public class DashboardRepository(AppDbContext _context) : IDashboardRepository
{
    public async Task<int> GetActiveProjectsCountAsync()
    {
        // Count all projects with Status == ProjectStatus.Active and not soft-deleted
        return await _context.Projects.CountAsync(p => p.Status == ProjectStatus.Active && !p.IsDeleted);
    }

    public async Task<int> GetPendingTasksCountAsync()
    {
        return await _context.Tasks.CountAsync(t => !t.IsCompleted);
    }

    public async Task<int> GetWorkersCountAsync()
    {
        // Count all workers that are not soft-deleted (IsDeleted == false)
        return await _context.Workers.CountAsync(w => !w.IsDeleted);
    }

    public async Task<int> GetDocumentsCountAsync()
    {
        // Count all documents that are not soft-deleted
        return await _context.Documnets.CountAsync(d => !d.IsDeleted);
    }

    public Task<ProjectTimelineDto> GetProjectTimelineAsync()
    {
        throw new System.NotImplementedException();
    }

    public Task<List<UpcomingTaskDto>> GetUpcomingTasksAsync()
    {
        throw new System.NotImplementedException();
    }
}
