using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;

public class DashboardRepository : IDashboardRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<DashboardRepository> _logger;

    public DashboardRepository(AppDbContext context, ILogger<DashboardRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<TeamStatisticsDto> GetTeamStatisticsAsync(string userId)
    {
        _logger.LogInformation("Getting team statistics for userId: {UserId}", userId);
        try
        {
            int userIdInt = int.Parse(userId);

            var totalWorkers = await _context.Workers.CountAsync(w => !w.IsDeleted && w.UserId == userIdInt);
            var assignedWorkers = await _context.Workers
                .CountAsync(w => !w.IsDeleted && w.TaskAssignments.Any() && w.UserId == userIdInt);
            var unAssignedWorkers = await _context.Workers
               .CountAsync(w => !w.IsDeleted && !w.TaskAssignments.Any() && w.UserId == userIdInt);

            var totalClients = await _context.Clients.CountAsync(c => !c.IsDeleted && c.UserId == userIdInt);
            //var totalSiteEngineers = await _context.SiteEngineers.CountAsync(c => !c.IsDeleted && c.UserId == userIdInt);

            _logger.LogInformation("Team stats for userId {UserId}: Workers={TotalWorkers}, Assigned={AssignedWorkers}, Unassigned={UnAssignedWorkers}, Clients={TotalClients}, SiteEngineers={TotalSiteEngineers}",
                userId, totalWorkers, assignedWorkers, unAssignedWorkers, totalClients);

            return new TeamStatisticsDto
            {
                TotalWorkers = totalWorkers,
                AssignedWorkers = assignedWorkers,
                UnAssignedWorkers = unAssignedWorkers,
                TotalClients = totalClients,
                //TotalSiteEngineers = totalSiteEngineers,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting team statistics for userId: {UserId}", userId);
            throw;
        }
    }

    public async Task<ProjectStatisticsDto> GetProjectsStatistics(string userId)
    {
        _logger.LogInformation("Getting project statistics for userId: {UserId}", userId);
        try
        {
            int userIdInt = int.Parse(userId);

            var total = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt);
            var active = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Active);
            var cancelled = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Cancelled);
            var completed = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Completed);
            var pending = await _context.Projects.CountAsync(p => !p.IsDeleted && p.Client.UserId == userIdInt && p.Status == ProjectStatus.Pending);

            _logger.LogInformation("Project stats for userId {UserId}: Total={Total}, Active={Active}, Cancelled={Cancelled}, Completed={Completed}, Pending={Pending}",
                userId, total, active, cancelled, completed, pending);

            return new ProjectStatisticsDto
            {
                TotalProjects = total,
                ActiveProjects = active,
                CancelledProjects = cancelled,
                CompletedProjects = completed,
                PendingProjects = pending
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting project statistics for userId: {UserId}", userId);
            throw;
        }
    }

    public async Task<TaskStatisticsDto> GetTasksStatisticsAync(string userId)
    {
        _logger.LogInformation("Getting task statistics for userId: {UserId}", userId);
        try
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

            _logger.LogInformation("Task stats for userId {UserId}: Total={Total}, Completed={Completed}, Active={Active}, Overdue={Overdue}",
                userId, total, completed, active, overdue);

            return new TaskStatisticsDto
            {
                TotalTasks = total,
                CompletedTasks = completed,
                ActiveTasks = active,
                OverdueTasks = overdue
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting task statistics for userId: {UserId}", userId);
            throw;
        }
    }

    public async Task<EquipmentStatisticsDto> GetEquipmentStatisticsAsync(string userId)
    {
        _logger.LogInformation("Getting equipment statistics for userId: {UserId}", userId);
        try
        {
            int userIdInt = int.Parse(userId);

            var totalEquipment = await _context.Equipments.CountAsync(e => e.UserId == userIdInt);
            var reservedEquipment = await _context.Equipments
                .CountAsync(e => e.UserId == userIdInt && e.Assignments.Any(r =>
                    r.StartDate <= DateTime.Now && r.EndDate >= DateTime.Now));
            var availableEquipment = totalEquipment - reservedEquipment;
            var totalReservation = await _context.EquipmentReservations.CountAsync(r =>
                _context.Equipments.Any(e => e.Id == r.EquipmentId && e.UserId == userIdInt));

            _logger.LogInformation("Equipment stats for userId {UserId}: Total={Total}, Reserved={Reserved}, Available={Available}, Reservations={Reservations}",
                userId, totalEquipment, reservedEquipment, availableEquipment, totalReservation);

            return new EquipmentStatisticsDto
            {
                TotalEquipments = totalEquipment,
                ReservedEquipments = reservedEquipment,
                AvailabeEquipments = availableEquipment,
                TotalReservation = totalReservation,
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting equipment statistics for userId: {UserId}", userId);
            throw;
        }
    }

    public async Task<DocumentsStatisticsDto> GetDocumentsStatisticsAsync(string userId)
    {
        _logger.LogInformation("Getting document statistics for userId: {UserId}", userId);
        try
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

            _logger.LogInformation("Document stats for userId {UserId}: Total={Total}, Images={Images}, OtherFiles={OtherFiles}",
                userId, totalDocuments, totalImages, totalOtherFiles);

            return new DocumentsStatisticsDto
            {
                TotalDocuments = totalDocuments,
                TotalImages = totalImages,
                TotalOtherFiles = totalOtherFiles
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting document statistics for userId: {UserId}", userId);
            throw;
        }
    }
}
