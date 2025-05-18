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

        if (status.HasValue)
        {
            filter = filter.AndAlso(e => e.Status == status.Value);
        }

        // Check for active reservations and update status if needed
        var equipmentIds = await _context.Equipments.Where(filter).Select(e => e.Id).ToListAsync();

        var activeReservations = await _context.Set<EquipmentReservation>()
            .Where(r => equipmentIds.Contains(r.EquipmentId) && r.StartDate <= DateTime.Now && r.EndDate > DateTime.Now)
            .Select(r => r.EquipmentId)
            .ToListAsync();

        var reservedIds = activeReservations;
        var availableIds = equipmentIds.Except(reservedIds).ToList();

        if (reservedIds.Any())
        {
            await _context.Equipments
                .Where(x => reservedIds.Contains(x.Id))
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Status, EquipmentStatus.Reserved)
                    .SetProperty(e => e.ModifiedDate, DateTime.Now));
        }

        if (availableIds.Any())
        {
            await _context.Equipments
                .Where(x => availableIds.Contains(x.Id))
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(e => e.Status, EquipmentStatus.Available)
                    .SetProperty(e => e.ModifiedDate, DateTime.Now));
        }

        var pagedResult = await GetPagedDataWithSelectionAsync(
            orderBy: x => x.Name,
            selector: EquipmentProfile.ToGetEquipmentDto(),
            criteria: filter,
            pageNumber: pageNumber,
            pageSize: pageSize);

        return pagedResult;
    }

    public async Task<EquipmentDetailsDto?> GetEquipmentById(int id)
    {

        var ActiveReservation = await _context.Set<EquipmentReservation>()
            .FirstOrDefaultAsync(r => r.EquipmentId == id && r.StartDate <= DateTime.Now && r.EndDate > DateTime.Now);


        if (ActiveReservation is not null)
        {
            await _context.Equipments
         .Where(x => x.Id == id)
         .ExecuteUpdateAsync(setters => setters
             .SetProperty(e => e.Status, EquipmentStatus.Reserved)
             .SetProperty(e => e.ModifiedDate, DateTime.Now));
        }
        else
        {
            await _context.Equipments
             .Where(x => x.Id == id)
             .ExecuteUpdateAsync(setters => setters
                 .SetProperty(e => e.Status, EquipmentStatus.Available)
                .SetProperty(e => e.ModifiedDate, DateTime.Now));
        }

        return await _context.Equipments
            .Include(e => e.Assignments)
            .ThenInclude(a => a.Project)
            .Where(e => e.Id == id)
            .Select(EquipmentProfile.ToEquipmentDetailsDto())
            .FirstOrDefaultAsync();
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


    public async Task<BaseResponse<string>> SetEquipmentStatusAsync(int equipmentId, EquipmentStatus status)
    {
        var equipment = await _context.Equipments.FindAsync(equipmentId);
        if (equipment == null)
            return new BaseResponse<string> { Success = false, Message = "المعدة غير موجودة" };

        equipment.Status = status;
        equipment.ModifiedDate = DateTime.Now;
        await _context.SaveChangesAsync();
        return new BaseResponse<string> { Success = true, Message = "تم تحديث حالة المعدة بنجاح" };
    }
}
