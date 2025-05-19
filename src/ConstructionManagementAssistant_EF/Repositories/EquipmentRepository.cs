namespace ConstructionManagementAssistant.EF.Repositories;


public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
{
    private readonly AppDbContext _context;

    public EquipmentRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<PagedResult<GetEquipmentDto>> GetAllEquipment(
        int pageNumber,
        int pageSize,
        string? searchTerm = null,
        EquipmentStatus? status = null)
    {
        // Build filter expression
        Expression<Func<Equipment, bool>> filter = x => true;

        if (!string.IsNullOrWhiteSpace(searchTerm))
        {
            filter = filter.AndAlso(e =>
                e.Name.Contains(searchTerm) ||
                e.Model.Contains(searchTerm) ||
                e.SerialNumber.Contains(searchTerm));
        }

        // Get all equipment matching filter
        var equipmentQuery = _context.Equipments.Where(filter);

        // Get all reservations with Started status
        // Get all reservations with Started status and current date within reservation period
        var currentDate = DateTime.Now;
        var startedReservations = await _context.EquipmentReservations
            .Where(r => r.StartDate <= currentDate && r.EndDate >= currentDate)
            .Select(r => r.EquipmentId)
            .ToListAsync();

        // Project to DTO and set status based on reservations
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

        // Filter by status if provided
        if (status.HasValue)
        {
            var statusString = status.Value.ToString();
            equipmentDtosQuery = equipmentDtosQuery.Where(e => e.Status == statusString);
        }

        // Paging
        var totalCount = await equipmentDtosQuery.CountAsync();
        var items = await equipmentDtosQuery
            .OrderBy(e => e.Name)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        return new PagedResult<GetEquipmentDto>
        {
            Items = items,
            TotalItems = totalCount,
            PageNumber = pageNumber,
            PageSize = pageSize
        };
    }

    public async Task<EquipmentDetailsDto?> GetEquipmentById(int id)
    {
        // Get all reservations with Started status for this equipment
        var currentDate = DateTime.Now;
        var hasStartedReservation = await _context.EquipmentReservations
            .AnyAsync(r => r.EquipmentId == id && r.StartDate <= currentDate && r.EndDate >= currentDate);

        var equipment = await _context.Equipments
            .Where(e => e.Id == id)
            .Select(e => new EquipmentDetailsDto
            {
                Id = e.Id,
                Name = e.Name,
                SerialNumber = e.SerialNumber,
                PurchaseDate = e.PurchaseDate,
                Status = hasStartedReservation
                    ? EquipmentStatus.Reserved.ToString()
                    : EquipmentStatus.Available.ToString()
            })
            .FirstOrDefaultAsync();

        return equipment;
    }

    public async Task<BaseResponse<string>> AddEquipmentAsync(AddEquipmentDto dto)
    {
        var entity = dto.ToEquipment();
        _context.Equipments.Add(entity);
        await _context.SaveChangesAsync();
        return new BaseResponse<string> { Success = true, Message = "تمت إضافة المعدة بنجاح" };
    }

    public async Task<BaseResponse<string>> UpdateEquipmentAsync(UpdateEquipmentDto dto)
    {
        var equipment = await _context.Equipments.FindAsync(dto.Id);
        if (equipment == null)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };

        equipment.UpdateEquipment(dto);
        await _context.SaveChangesAsync();
        return new BaseResponse<string> { Success = true, Message = "تم تحديث المعدة بنجاح" };
    }

    public async Task<BaseResponse<string>> DeleteEquipmentAsync(int id)
    {
        var equipment = await _context.Equipments.FindAsync(id);
        if (equipment == null)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };

        _context.Equipments.Remove(equipment);
        await _context.SaveChangesAsync();
        return new BaseResponse<string> { Success = true, Message = "تم حذف المعدة بنجاح" };
    }



}
