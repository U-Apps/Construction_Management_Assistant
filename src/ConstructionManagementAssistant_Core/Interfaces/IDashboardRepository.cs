namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IDashboardRepository
    {
        Task<int> GetActiveProjectsCountAsync();
        Task<int> GetPendingTasksCountAsync();
        Task<int> GetWorkersCountAsync();
        Task<int> GetDocumentsCountAsync();
        Task<int> GetAssignedWorkersAsync();
        Task<int> GetUnAssignedWorkersAsync();
        Task<int> GetTotalProjectsAsync();
        Task<int> GetOverdueTaskssync();

        Task<ProjectTimelineDto> GetProjectTimelineAsync();
        Task<List<UpcomingTaskDto>> GetUpcomingTasksAsync();
    }

    // DTOs for dashboard data (define these in your DTOs folder as needed)
    public class ProjectTimelineDto
    {
        public List<string> Months { get; set; }
        public List<int> Completed { get; set; }
        public List<int> Planned { get; set; }
    }

    public class UpcomingTaskDto
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string DueDate { get; set; }
        public string Priority { get; set; }
    }
}
