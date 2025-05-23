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


        // Check for overlapping reservation and get the first one found
        var overlappingReservation = await _context.EquipmentReservations
            .Where(r =>
                r.EquipmentId == equipmentId &&
                (startDate < r.EndDate && endDate > r.StartDate))
            .FirstOrDefaultAsync();

        if (overlappingReservation != null)
        {
            return new BaseResponse<string>
            {
                Success = false,
                Message = $"هناك حجز آخر متداخل لهذه المعدة في الفترة من {overlappingReservation.StartDate:yyyy-MM-dd} إلى {overlappingReservation.EndDate:yyyy-MM-dd}"
            };
        }


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

    public async Task<BaseResponse<string>> DeleteEquipmentReservationAsync(int equipmentReservationId)
    {
        _logger.LogInformation("Canceling equipment reservation {ReservationId}", equipmentReservationId);

        var reservation = await _context.EquipmentReservations
            .FirstOrDefaultAsync(a => a.Id == equipmentReservationId);

        if (reservation == null)
            return new BaseResponse<string> { Success = false, Message = "الحجز غير موجود" };

        if (reservation.ReservationStatus == ReservationStatus.Compoleted)
            return new BaseResponse<string> { Success = false, Message = "لا يمكن إلغاء حجز مكتمل" };


        _context.EquipmentReservations.Remove(reservation);
        await _context.SaveChangesAsync();

        _logger.LogInformation("Equipment reservation {ReservationId} canceled", equipmentReservationId);

        return new BaseResponse<string> { Success = true, Message = "تم إلغاء حجز المعدة بنجاح" };
    }


    private static ReservationStatus GetReservationStatus(DateTime startDate, DateTime endDate, DateTime now)
    {
        if (endDate <= now)
            return ReservationStatus.Compoleted;
        else if (startDate > now)
            return ReservationStatus.NotStarted;
        else
            return ReservationStatus.Started;
    }

    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByEquipmentIdAsync(int equipmentId)
    {
        var now = DateTime.Now;
        var reservations = await _context.EquipmentReservations
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
                ReservationStatus = GetReservationStatus(a.StartDate, a.EndDate, now)
            })
            .ToListAsync();


        return reservations;
    }

    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByProjectIdAsync(int projectId)
    {
        var now = DateTime.Now;
        var reservations = await _context.EquipmentReservations
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
                ReservationStatus = GetReservationStatus(a.StartDate, a.EndDate, now)
            })
            .ToListAsync();


        return reservations;
    }

    public async Task<List<GetEquipmentReservationDto>> GetAllEquipmentReservationsAsync(string userId)
    {
        var now = DateTime.Now;
        var reservations = await _context.EquipmentReservations.Where(x => x.Equipment.UserId == int.Parse(userId))
            .Select(a => new GetEquipmentReservationDto
            {
                Id = a.Id,
                ProjectId = a.ProjectId,
                ProjectName = a.Project.Name,
                EquipmentId = a.Equipment.Id,
                EquipmentName = a.Equipment.Name,
                StartDate = a.StartDate,
                EndDate = a.EndDate,
                ReservationStatus = GetReservationStatus(a.StartDate, a.EndDate, now)
            })
            .ToListAsync();


        return reservations;
    }

}
