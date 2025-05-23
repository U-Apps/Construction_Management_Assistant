using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _context;

    public DashboardRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TeamStatisticsDto> GetTeamStatisticsAsync(string userId)
    {
        int userIdInt = int.Parse(userId);

        var totalWorkers = await _context.Workers.CountAsync(w => !w.IsDeleted && w.UserId == userIdInt);
        var assignedWorkers = await _context.Workers
            .CountAsync(w => !w.IsDeleted && w.TaskAssignments.Any() && w.UserId == userIdInt);
        var unAssignedWorkers = await _context.Workers
           .CountAsync(w => !w.IsDeleted && !w.TaskAssignments.Any() && w.UserId == userIdInt);

        var totalClients = await _context.Clients.CountAsync(c => !c.IsDeleted && c.UserId == userIdInt);
        var totalSiteEngineers = await _context.SiteEngineers.CountAsync(c => !c.IsDeleted && c.UserId == userIdInt);

        return new TeamStatisticsDto
        {
            TotalWorkers = totalWorkers,
            AssignedWorkers = assignedWorkers,
            UnAssignedWorkers = unAssignedWorkers,
            TotalClients = totalClients,
            TotalSiteEngineers = totalSiteEngineers,
        };
    }

    public async Task<ProjectStatisticsDto> GetProjectsStatistics(string userId)
    {
        int userIdInt = int.Parse(userId);

        var total = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt);
        var active = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Active);
        var cancelled = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Cancelled);
        var completed = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Completed);
        var pending = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Pending);

        return new ProjectStatisticsDto
        {
            TotalProjects = total,
            ActiveProjects = active,
            CancelledProjects = cancelled,
            CompletedProjects = completed,
            PendingProjects = pending
        };
    }

    public async Task<TaskStatisticsDto> GetTasksStatisticsAync(string userId)
    {
        int userIdInt = int.Parse(userId);
        var tasks = _context.Set<ProjectTask>();
        var now = DateOnly.FromDateTime(DateTime.Now);

        var total = await tasks.CountAsync(t => t.Stage.Project.Client.UserId == userIdInt);

        var completed = await tasks.CountAsync(t => t.Stage.Project.Client.UserId == userIdInt && t.IsCompleted);

        var active = await tasks.CountAsync(t => t.Stage.Project.Client.UserId == userIdInt && !t.IsCompleted);

        var overdue = await tasks.CountAsync(t =>
            !t.IsCompleted &&
            t.ExpectedEndDate != null &&
            t.ExpectedEndDate < now &&
            t.Stage.Project.Client.UserId == userIdInt);

        return new TaskStatisticsDto
        {
            TotalTasks = total,
            CompletedTasks = completed,
            ActiveTasks = active,
            OverdueTasks = overdue
        };
    }

    public async Task<EquipmentStatisticsDto> GetEquipmentStatisticsAsync(string userId)
    {
        int userIdInt = int.Parse(userId);

        var totalEquipment = await _context.Equipments.CountAsync(e => e.UserId == userIdInt);
        var reservedEquipment = await _context.Equipments
            .CountAsync(e => e.UserId == userIdInt && e.Assignments != null && e.Assignments.Any(r =>
                r.StartDate <= DateTime.Now && r.EndDate >= DateTime.Now));
        var availableEquipment = totalEquipment - reservedEquipment;
        var totalReservation = await _context.EquipmentReservations.CountAsync(r =>
            _context.Equipments.Any(e => e.Id == r.EquipmentId && e.UserId == userIdInt));

        return new EquipmentStatisticsDto
        {
            TotalEquipments = totalEquipment,
            ReservedEquipments = reservedEquipment,
            AvailabeEquipments = availableEquipment,
            TotalReservation = totalReservation,
        };
    }

    public async Task<DocumentsStatisticsDto> GetDocumentsStatisticsAsync(string userId)
    {
        int userIdInt = int.Parse(userId);

        var totalDocuments = await _context.Documents.CountAsync(d =>
            !d.IsDeleted && d.Project.Client.UserId == userIdInt);

        var totalImages = await _context.Documents.CountAsync(d =>
            !d.IsDeleted &&
            (
                d.FileType.ToLower().Contains("image") ||
                d.FileType.ToLower() == ".jpg" ||
                d.FileType.ToLower() == ".jpeg" ||
                d.FileType.ToLower() == ".png" ||
                d.FileType.ToLower() == ".gif" ||
                d.FileType.ToLower() == ".bmp" ||
                d.FileType.ToLower() == ".webp"
            ) &&
            d.Project.Client.UserId == userIdInt);
        var totalOtherFiles = totalDocuments - totalImages;

        return new DocumentsStatisticsDto
        {
            TotalDocuments = totalDocuments,
            TotalImages = totalImages,
            TotalOtherFiles = totalOtherFiles
        };
    }
}
