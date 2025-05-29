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
        _logger.LogInformation("Reserving equipment {EquipmentId} for project {ProjectId} from {StartDate} to {EndDate}", equipmentId, projectId, startDate, endDate);

        try
        {
            var equipment = await _context.Equipments.FindAsync(equipmentId);
            if (equipment == null)
            {
                _logger.LogWarning("Equipment with ID: {EquipmentId} not found", equipmentId);
                return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };
            }

            var project = await _context.Projects.FindAsync(projectId);
            if (project is null)
            {
                _logger.LogWarning("Project with ID: {ProjectId} not found", projectId);
                return new BaseResponse<string> { Success = false, Message = "المشروع غير موجود" };
            }

            if (project.Status == ProjectStatus.Cancelled || project.Status == ProjectStatus.Pending)
            {
                _logger.LogWarning("Project {ProjectId} is not active (status: {Status})", projectId, project.Status);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المشروع غير فعال"
                };
            }

            var overlappingReservation = await _context.EquipmentReservations
                .Where(r =>
                    r.EquipmentId == equipmentId &&
                    (startDate < r.EndDate && endDate > r.StartDate))
                .FirstOrDefaultAsync();

            if (overlappingReservation != null)
            {
                _logger.LogWarning("Overlapping reservation found for equipment {EquipmentId} in period {StartDate} to {EndDate}", equipmentId, overlappingReservation.StartDate, overlappingReservation.EndDate);
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
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error reserving equipment {EquipmentId} for project {ProjectId}", equipmentId, projectId);
            throw;
        }
    }

    public async Task<BaseResponse<string>> DeleteEquipmentReservationAsync(int equipmentReservationId)
    {
        _logger.LogInformation("Canceling equipment reservation {ReservationId}", equipmentReservationId);

        try
        {
            var reservation = await _context.EquipmentReservations
                .FirstOrDefaultAsync(a => a.Id == equipmentReservationId);

            if (reservation == null)
            {
                _logger.LogWarning("Reservation with ID: {ReservationId} not found", equipmentReservationId);
                return new BaseResponse<string> { Success = false, Message = "الحجز غير موجود" };
            }

            if (reservation.ReservationStatus == ReservationStatus.Compoleted)
            {
                _logger.LogWarning("Cannot cancel completed reservation {ReservationId}", equipmentReservationId);
                return new BaseResponse<string> { Success = false, Message = "لا يمكن إلغاء حجز مكتمل" };
            }

            _context.EquipmentReservations.Remove(reservation);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Equipment reservation {ReservationId} canceled", equipmentReservationId);

            return new BaseResponse<string> { Success = true, Message = "تم إلغاء حجز المعدة بنجاح" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error canceling equipment reservation {ReservationId}", equipmentReservationId);
            throw;
        }
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
        _logger.LogInformation("Fetching reservations for equipmentId: {EquipmentId}", equipmentId);

        try
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

            _logger.LogInformation("Fetched {Count} reservations for equipmentId: {EquipmentId}", reservations.Count, equipmentId);

            return reservations;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching reservations for equipmentId: {EquipmentId}", equipmentId);
            throw;
        }
    }

    public async Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByProjectIdAsync(int projectId)
    {
        _logger.LogInformation("Fetching reservations for projectId: {ProjectId}", projectId);

        try
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

            _logger.LogInformation("Fetched {Count} reservations for projectId: {ProjectId}", reservations.Count, projectId);

            return reservations;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching reservations for projectId: {ProjectId}", projectId);
            throw;
        }
    }

    public async Task<List<GetEquipmentReservationDto>> GetAllEquipmentReservationsAsync(string userId)
    {
        _logger.LogInformation("Fetching all reservations for userId: {UserId}", userId);

        try
        {
            var now = DateTime.Now;
            var reservations = await _context.EquipmentReservations
                .Where(x => x.Equipment.UserId == int.Parse(userId))
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

            _logger.LogInformation("Fetched {Count} reservations for userId: {UserId}", reservations.Count, userId);

            return reservations;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching reservations for userId: {UserId}", userId);
            throw;
        }
    }
}
