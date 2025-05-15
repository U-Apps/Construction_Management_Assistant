using ConstructionManagementAssistant.Core.Models.Response;

public interface IEquipmentAssignmentRepository
{
    Task<BaseResponse<string>> AssignEquipmentToProjectAsync(int equipmentId, int projectId, DateTime expectedReturnDate);
    Task<BaseResponse<string>> UnassignEquipmentFromProjectAsync(int equipmentAssignmentId);
    Task<List<GetEquipmentAssignmentDto>> GetAssignmentsByEquipmentIdAsync(int equipmentId);
    Task<List<GetEquipmentAssignmentDto>> GetAssignmentsByProjectIdAsync(int projectId);
}
