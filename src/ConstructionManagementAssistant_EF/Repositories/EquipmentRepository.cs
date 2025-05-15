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
