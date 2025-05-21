using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces;
public interface IEquipmentReservationRepository
{
    Task<BaseResponse<string>> ReserveEquipmentForProjectAsync(int equipmentId, int projectId, DateTime startDate, DateTime endDate);
    Task<BaseResponse<string>> DeleteEquipmentReservationAsync(int equipmentReservationId);
    Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByEquipmentIdAsync(int equipmentId);
    Task<List<GetEquipmentReservationDto>> GetEquipmentReservationsByProjectIdAsync(int projectId);
    Task<List<GetEquipmentReservationDto>> GetAllEquipmentReservationsAsync();

}
