using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

namespace ConstructionManagementAssistant.Core.Repositories;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _context;

    public DashboardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TeamStatisticsDto> GetTeamStatisticsAsync()
    {
        var totalWorkers = await _context.Workers.CountAsync(w => !w.IsDeleted);
        var assignedWorkers = await _context.Workers
            .CountAsync(w => !w.IsDeleted && w.TaskAssignments.Any());
        var unAssignedWorkers = await _context.Workers
           .CountAsync(w => !w.IsDeleted && w.TaskAssignments.Any());

        var totalClients = await _context.Clients.CountAsync(c => !c.IsDeleted);
        var totalSiteEngineers = await _context.SiteEngineers.CountAsync(c => !c.IsDeleted);

        return new TeamStatisticsDto
        {
            TotalWorkers = totalWorkers,
            AssignedWorkers = assignedWorkers,
            UnAssignedWorkers = unAssignedWorkers,
            TotalClients = totalClients,
            TotalSiteEngineers = totalSiteEngineers,
        };
    }

    public async Task<ProjectStatisticsDto> GetProjectsStatistics()
    {
        var total = await _context.Projects.CountAsync(p => !p.IsDeleted);
        var active = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Status == ProjectStatus.Active);
        var cancelled = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Status == ProjectStatus.Cancelled);
        var completed = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Status == ProjectStatus.Completed);
        var pending = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Status == ProjectStatus.Pending);

        return new ProjectStatisticsDto
        {
            TotalProjects = total,
            ActiveProjects = active,
            CancelledProjects = cancelled,
            CompletedProjects = completed,
            PendingProjects = pending
        };
    }

    public async Task<TaskStatisticsDto> GetTasksStatisticsAync()
    {
        var tasks = _context.Set<ProjectTask>();
        var now = DateOnly.FromDateTime(DateTime.Now);

        var total = await tasks.CountAsync();
        var completed = await tasks.CountAsync(t => t.IsCompleted);
        var active = await tasks.CountAsync(t => !t.IsCompleted);
        var overdue = await tasks.CountAsync(t =>
            !t.IsCompleted &&
            t.ExpectedEndDate != null &&
            t.ExpectedEndDate < now
        );

        return new TaskStatisticsDto
        {
            TotalTasks = total,
            CompletedTasks = completed,
            ActiveTasks = active,
            OverdueTasks = overdue
        };
    }

    public async Task<EquipmentStatisticsDto> GetEquipmentStatisticsAsync()
    {
        var totalEquipment = await _context.Equipments.CountAsync();
        var reservedEquipment = await _context.Equipments
            .CountAsync(e => e.Assignments != null && e.Assignments.Any(r =>
                r.StartDate <= DateTime.Now && r.EndDate >= DateTime.Now));
        var availableEquipment = totalEquipment - reservedEquipment;
        var totalReservation = await _context.EquipmentReservations.CountAsync();

        return new EquipmentStatisticsDto
        {
            TotalEquipments = totalEquipment,
            ReservedEquipments = reservedEquipment,
            AvailabeEquipments = availableEquipment,
            TotalReservation = totalReservation,
        };
    }

    public async Task<DocumentsStatisticsDto> GetDocumentsStatisticsAsync()
    {
        var totalDocuments = await _context.Documnets.CountAsync(d => !d.IsDeleted);
        var totalImages = await _context.Documnets.CountAsync(d => !d.IsDeleted && (
            d.FileType.ToLower().Contains("image") ||
            d.FileType.ToLower() == ".jpg" ||
            d.FileType.ToLower() == ".jpeg" ||
            d.FileType.ToLower() == ".png" ||
            d.FileType.ToLower() == ".gif" ||
            d.FileType.ToLower() == ".bmp" ||
            d.FileType.ToLower() == ".webp"
        ));
        var totalOtherFiles = totalDocuments - totalImages;

        return new DocumentsStatisticsDto
        {
            TotalDocuments = totalDocuments,
            TotalImages = totalImages,
            TotalOtherFiles = totalOtherFiles
        };
    }
}
