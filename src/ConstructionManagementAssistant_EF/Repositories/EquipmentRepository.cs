namespace ConstructionManagementAssistant.EF.Repositories;

public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
{
    private readonly AppDbContext _context;
    private readonly ILogger<EquipmentRepository> _logger;

    public EquipmentRepository(AppDbContext context, ILogger<EquipmentRepository> logger) : base(context)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<PagedResult<GetEquipmentDto>> GetAllEquipment(
        string userId,
        int pageNumber,
        int pageSize,
        string? searchTerm = null,
        EquipmentStatus? status = null)
    {
        _logger.LogInformation("Fetching equipment for userId: {UserId}, page: {PageNumber}, size: {PageSize}, search: {SearchTerm}, status: {Status}",
            userId, pageNumber, pageSize, searchTerm, status);

        try
        {
            Expression<Func<Equipment, bool>> filter = x => true;
            filter = filter.AndAlso(x => x.UserId == int.Parse(userId));

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                filter = filter.AndAlso(e =>
                    e.Name.Contains(searchTerm) ||
                    e.Model.Contains(searchTerm) ||
                    e.SerialNumber.Contains(searchTerm));
            }

            var equipmentQuery = _context.Equipments.Where(filter);

            var currentDate = DateTime.Now;
            var startedReservations = await _context.EquipmentReservations
                .Where(r => r.StartDate <= currentDate && r.EndDate >= currentDate)
                .Select(r => r.EquipmentId)
                .ToListAsync();

            var equipmentDtosQuery = equipmentQuery.Select(e => new GetEquipmentDto
            {
                Id = e.Id,
                Name = e.Name,
                Model = e.Model,
                PurchaseDate = e.PurchaseDate,
                Status = startedReservations.Contains(e.Id)
                    ? EquipmentStatus.Reserved.ToString()
                    : EquipmentStatus.Available.ToString()
            });

            if (status.HasValue)
            {
                var statusString = status.Value.ToString();
                equipmentDtosQuery = equipmentDtosQuery.Where(e => e.Status == statusString);
            }

            var totalItems = await equipmentDtosQuery.CountAsync();
            var items = await equipmentDtosQuery
                .OrderBy(e => e.Name)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            _logger.LogInformation("Fetched {Count} equipment items for userId: {UserId}", items.Count, userId);

            return new PagedResult<GetEquipmentDto>
            {
                Items = items,
                TotalItems = totalItems,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize)
            };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching equipment for userId: {UserId}", userId);
            throw;
        }
    }

    public async Task<EquipmentDetailsDto?> GetEquipmentById(int id)
    {
        _logger.LogInformation("Fetching equipment details for ID: {Id}", id);

        try
        {
            var currentDate = DateTime.Now;
            var hasStartedReservation = await _context.EquipmentReservations
                .AnyAsync(r => r.EquipmentId == id && r.StartDate <= currentDate && r.EndDate >= currentDate);

            var equipment = await _context.Equipments
                .Where(e => e.Id == id)
                .Select(e => new EquipmentDetailsDto
                {
                    Id = e.Id,
                    Name = e.Name,
                    Model = e.Model,
                    Notes = e.Notes,
                    SerialNumber = e.SerialNumber,
                    PurchaseDate = e.PurchaseDate,
                    Status = hasStartedReservation
                        ? EquipmentStatus.Reserved.ToString()
                        : EquipmentStatus.Available.ToString()
                })
                .FirstOrDefaultAsync();

            if (equipment == null)
            {
                _logger.LogWarning("Equipment with ID: {Id} not found", id);
            }
            else
            {
                _logger.LogInformation("Equipment with ID: {Id} fetched successfully", id);
            }

            return equipment;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error fetching equipment details for ID: {Id}", id);
            throw;
        }
    }

    public async Task<BaseResponse<string>> AddEquipmentAsync(string userId, AddEquipmentDto dto)
    {
        _logger.LogInformation("Adding equipment for userId: {UserId}, name: {Name}", userId, dto.Name);

        try
        {
            var entity = dto.ToEquipment();
            entity.UserId = int.Parse(userId);
            _context.Equipments.Add(entity);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Equipment added successfully: {Name}", dto.Name);

            return new BaseResponse<string> { Success = true, Message = "تمت إضافة المعدة بنجاح" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error adding equipment for userId: {UserId}, name: {Name}", userId, dto.Name);
            throw;
        }
    }

    public async Task<BaseResponse<string>> UpdateEquipmentAsync(UpdateEquipmentDto dto)
    {
        _logger.LogInformation("Updating equipment with ID: {Id}", dto.Id);

        try
        {
            var equipment = await _context.Equipments.FindAsync(dto.Id);
            if (equipment == null)
            {
                _logger.LogWarning("Equipment with ID: {Id} not found for update", dto.Id);
                return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };
            }

            equipment.UpdateEquipment(dto);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Equipment with ID: {Id} updated successfully", dto.Id);

            return new BaseResponse<string> { Success = true, Message = "تم تحديث المعدة بنجاح" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error updating equipment with ID: {Id}", dto.Id);
            throw;
        }
    }

    public async Task<BaseResponse<string>> DeleteEquipmentAsync(int id)
    {
        _logger.LogInformation("Deleting equipment with ID: {Id}", id);

        try
        {
            var equipment = await _context.Equipments.FindAsync(id);
            if (equipment == null)
            {
                _logger.LogWarning("Equipment with ID: {Id} not found for delete", id);
                return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };
            }

            _context.Equipments.Remove(equipment);
            await _context.SaveChangesAsync();

            _logger.LogInformation("Equipment with ID: {Id} deleted successfully", id);

            return new BaseResponse<string> { Success = true, Message = "تم حذف المعدة بنجاح" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error deleting equipment with ID: {Id}", id);
            throw;
        }
    }
}
