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

        if (!await _context.Projects.AnyAsync(x => x.Id == projectId))
            return new BaseResponse<string> { Success = false, Message = "المشروع غير موجود" };

        if (equipment.Status != EquipmentStatus.Available)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير متاحة للحجز" };

        // Overlap prevention: check for conflicting reservations
        bool hasConflict = await _context.EquipmentReservations
            .AnyAsync(r =>
                r.EquipmentId == equipmentId &&
                (startDate < r.EndDate && endDate > r.StartDate) || (startDate > r.EndDate && endDate < r.StartDate)
            );


        if (hasConflict)
            return new BaseResponse<string> { Success = false, Message = "هناك حجز آخر متداخل لهذه المعدة في الفترة المحددة" };

        var reservation = new EquipmentReservation
        {
            EquipmentId = equipmentId,
            ProjectId = projectId,
            StartDate = startDate,
            EndDate = endDate,
        };

        _context.EquipmentReservations.Add(reservation);
        await _context.SaveChangesAsync();


        _logger.LogInformation("Equipment {EquipmentId} reserved for project {ProjectId}", equipmentId, projectId);

        return new BaseResponse<string> { Success = true, Message = "تم حجز المعدة للمشروع بنجاح" };
    }

    public async Task<BaseResponse<string>> RemoveEquipmentReservationAsync(int equipmentReservationId)
    {
        _logger.LogInformation("Removing equipment reservation {ReservationId}", equipmentReservationId);

        var reservation = await _context.EquipmentReservations
            .FirstOrDefaultAsync(a => a.Id == equipmentReservationId);

        if (reservation == null)
            return new BaseResponse<string> { Success = false, Message = "الحجز غير موجود" };

        // Remove the reservation from the database
        _context.EquipmentReservations.Remove(reservation);

        await _context.SaveChangesAsync();

        _logger.LogInformation("Equipment reservation {ReservationId} removed", equipmentReservationId);

        return new BaseResponse<string> { Success = true, Message = "تم إلغاء حجز المعدة بنجاح" };
    }


    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByEquipmentIdAsync(int equipmentId)
    {
        var now = DateTime.Now;
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
                IsActive = IsReservationActive(a.StartDate, a.EndDate, now)
            }).ToListAsync();
    }

    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByProjectIdAsync(int projectId)
    {
        var now = DateTime.Now;
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
                IsActive = IsReservationActive(a.StartDate, a.EndDate, now)
            }).ToListAsync();
    }

    public async Task<List<GetEquipmentReservationDto>> GetAllEquipmentReservationsAsync()
    {
        var now = DateTime.Now;
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
                IsActive = IsReservationActive(a.StartDate, a.EndDate, now)
            }).ToListAsync();
    }
    private static bool IsReservationActive(DateTime startDate, DateTime endDate, DateTime? reference = null)
    {
        var now = reference ?? DateTime.Now;
        var result = startDate <= now && endDate > now;
        return result;
    }


}
