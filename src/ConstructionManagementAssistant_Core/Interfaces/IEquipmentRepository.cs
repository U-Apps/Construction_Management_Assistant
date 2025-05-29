using ConstructionManagementAssistant.Core.Models.Response;

public interface IEquipmentRepository
{
    Task<PagedResult<GetEquipmentDto>> GetAllEquipment(string userId, int pageNumber, int pageSize, string? searchTerm = null, EquipmentStatus? status = null);
    Task<EquipmentDetailsDto?> GetEquipmentById(int id);
    Task<BaseResponse<string>> AddEquipmentAsync(string userId, AddEquipmentDto dto);
    Task<BaseResponse<string>> UpdateEquipmentAsync(UpdateEquipmentDto dto);
    Task<BaseResponse<string>> DeleteEquipmentAsync(int id);

}
