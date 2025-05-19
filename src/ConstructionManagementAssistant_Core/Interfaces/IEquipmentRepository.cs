using ConstructionManagementAssistant.Core.Models.Response;

public interface IEquipmentRepository
{
    Task<PagedResult<GetEquipmentDto>> GetAllEquipment(int pageNumber, int pageSize, string? searchTerm = null, EquipmentStatus? status = null);
    Task<EquipmentDetailsDto?> GetEquipmentById(int id);
    Task<BaseResponse<string>> AddEquipmentAsync(AddEquipmentDto dto);
    Task<BaseResponse<string>> UpdateEquipmentAsync(UpdateEquipmentDto dto);
    Task<BaseResponse<string>> DeleteEquipmentAsync(int id);

}
