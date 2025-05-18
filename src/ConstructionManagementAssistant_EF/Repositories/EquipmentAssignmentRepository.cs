namespace ConstructionManagementAssistant.EF.Repositories;

public class EquipmentReservationRepository : IEquipmentReservationRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<EquipmentReservationRepository> _logger;

    public EquipmentReservationRepository(AppDbContext context, ILogger<EquipmentReservationRepository> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<BaseResponse<string>> ReserveEquipmentForProjectAsync(int equipmentId, int projectId, DateTime startDate, DateTime endDate)
    {
        _logger.LogInformation("Reserving equipment {EquipmentId} for project {ProjectId}", equipmentId, projectId);

        var equipment = await _context.Equipments.FindAsync(equipmentId);
        if (equipment == null)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };

        var project = await _context.Projects.FindAsync(projectId);
        if (project == null)
            return new BaseResponse<string> { Success = false, Message = "المشروع غير موجود" };

        if (equipment.Status != EquipmentStatus.Available)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير متاحة للحجز" };

        // Overlap prevention: check for conflicting reservations
        bool hasConflict = await _context.EquipmentReservations
            .AnyAsync(r =>
                r.EquipmentId == equipmentId &&
                !r.IsCompleted &&
                (
                    (startDate < r.EndDate && endDate > r.StartDate)
                )
            );

        if (hasConflict)
            return new BaseResponse<string> { Success = false, Message = "هناك حجز آخر متداخل لهذه المعدة في الفترة المحددة" };

        var reservation = new EquipmentReservation
        {
            EquipmentId = equipmentId,
            ProjectId = projectId,
            StartDate = startDate,
            EndDate = endDate,
            IsCompleted = false
        };

        equipment.Status = EquipmentStatus.Reserved;
        equipment.ModifiedDate = DateTime.Now;
        _context.EquipmentReservations.Add(reservation);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Equipment {EquipmentId} reserved for project {ProjectId}", equipmentId, projectId);

        return new BaseResponse<string> { Success = true, Message = "تم حجز المعدة للمشروع بنجاح" };
    }

    public async Task<BaseResponse<string>> RemoveEquipmentReservationAsync(int equipmentReservationId)
    {
        _logger.LogInformation("Removing equipment reservation {ReservationId}", equipmentReservationId);

        var reservation = await _context.EquipmentReservations
            .Include(a => a.Equipment)
            .FirstOrDefaultAsync(a => a.Id == equipmentReservationId);

        if (reservation == null)
            return new BaseResponse<string> { Success = false, Message = "الحجز غير موجود" };

        reservation.Equipment.Status = EquipmentStatus.Available;
        reservation.Equipment.ModifiedDate = DateTime.Now;
        reservation.IsCompleted = true;
        // If you have ActualReturnDate, set it here:
        // reservation.ActualReturnDate = DateTime.Now;
        await _context.SaveChangesAsync();

        _logger.LogInformation("Equipment reservation {ReservationId} removed", equipmentReservationId);

        return new BaseResponse<string> { Success = true, Message = "تم إلغاء حجز المعدة بنجاح" };
    }

    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByEquipmentIdAsync(int equipmentId)
    {
        return await _context.EquipmentReservations
            .Where(a => a.EquipmentId == equipmentId)
            .Select(a => new GetEquipmentReservationDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                EquipmentId = a.Equipment.Id,
                EquipmentName = a.Equipment.Name,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                IsCompleted = a.IsCompleted
                // If you have ActualReturnDate, map it here
            }).ToListAsync();
    }

    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByProjectIdAsync(int projectId)
    {
        return await _context.EquipmentReservations
            .Where(a => a.ProjectId == projectId)
            .Select(a => new GetEquipmentReservationDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                EquipmentId = a.Equipment.Id,
                EquipmentName = a.Equipment.Name,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                IsCompleted = a.IsCompleted
                // If you have ActualReturnDate, map it here
            }).ToListAsync();
    }

    public async Task<List<GetEquipmentReservationDto>> GetAllEquipmentReservationsAsync()
    {
        return await _context.EquipmentReservations
            .Select(a => new GetEquipmentReservationDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                EquipmentId = a.Equipment.Id,
                EquipmentName = a.Equipment.Name,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                IsCompleted = a.IsCompleted
                // If you have ActualReturnDate, map it here
            }).ToListAsync();
    }
}
