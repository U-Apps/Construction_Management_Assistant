namespace ConstructionManagementAssistant.EF.Repositories;

public class EquipmentAssignmentRepository : IEquipmentAssignmentRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<EquipmentAssignmentRepository> _logger;

    public EquipmentAssignmentRepository(AppDbContext context, ILogger<EquipmentAssignmentRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<BaseResponse<string>> AssignEquipmentToProjectAsync(int equipmentId, int projectId, DateTime expectedReturnDate)
    {
        _logger.LogInformation("Assigning equipment {EquipmentId} to project {ProjectId}", equipmentId, projectId);

        var equipment = await _context.Equipments.FindAsync(equipmentId);
        if (equipment == null)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };

        var project = await _context.Projects.FindAsync(projectId);
        if (project == null)
            return new BaseResponse<string> { Success = false, Message = "المشروع غير موجود" };

        if (equipment.Status != EquipmentStatus.Available)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير متاحة للحجز" };

        var assignment = new EquipmentAssignment
        {
            EquipmentId = equipmentId,
            ProjectId = projectId,
            BookDate = DateTime.Now,
            ExpectedReturnDate = expectedReturnDate
        };

        equipment.Status = EquipmentStatus.InUse;
        equipment.ModifiedDate = DateTime.Now;
        _context.EquipmentAssignments.Add(assignment);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Equipment {EquipmentId} assigned to project {ProjectId}", equipmentId, projectId);

        return new BaseResponse<string> { Success = true, Message = "تم حجز المعدة للمشروع بنجاح" };
    }

    public async Task<BaseResponse<string>> UnassignEquipmentFromProjectAsync(int equipmentAssignmentId)
    {
        _logger.LogInformation("Unassigning equipment assignment {AssignmentId}", equipmentAssignmentId);

        var assignment = await _context.EquipmentAssignments
            .Include(a => a.Equipment)
            .FirstOrDefaultAsync(a => a.Id == equipmentAssignmentId);

        if (assignment == null)
            return new BaseResponse<string> { Success = false, Message = "الحجز غير موجود" };

        assignment.Equipment.Status = EquipmentStatus.Available;
        assignment.Equipment.ModifiedDate = DateTime.Now;
        assignment.ActualReturnDate = DateTime.Now;
        //_context.EquipmentAssignments.Remove(assignment);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Equipment assignment {AssignmentId} removed", equipmentAssignmentId);

        return new BaseResponse<string> { Success = true, Message = "تم إلغاء حجز المعدة بنجاح" };
    }

    public async Task<List<GetEquipmentAssignmentDto>> GetAssignmentsByEquipmentIdAsync(int equipmentId)
    {
        return await _context.EquipmentAssignments
            .Where(a => a.EquipmentId == equipmentId)
            .Select(a => new GetEquipmentAssignmentDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                EquipmentId = a.Equipment.Id,
                EquipmentName = a.Equipment.Name,
                BookDate = a.BookDate,
                ExpectedReturnDate = a.ExpectedReturnDate,
                ActualReturnDate = a.ActualReturnDate
            }).ToListAsync();
    }

    public async Task<List<GetEquipmentAssignmentDto>> GetAssignmentsByProjectIdAsync(int projectId)
    {
        return await _context.EquipmentAssignments
            .Where(a => a.ProjectId == projectId)
            .Select(a => new GetEquipmentAssignmentDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                EquipmentId = a.Equipment.Id,
                EquipmentName = a.Equipment.Name,
                BookDate = a.BookDate,
                ExpectedReturnDate = a.ExpectedReturnDate,
                ActualReturnDate = a.ActualReturnDate
            }).ToListAsync();
    }
}
