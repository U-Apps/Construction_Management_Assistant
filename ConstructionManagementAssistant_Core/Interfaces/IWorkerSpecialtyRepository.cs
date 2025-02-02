using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;

namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IWorkerSpecialtyRepository : IBaseRepository<WorkerSpecialty>
    {
        public Task<GetWorkerSpecialtyDto?> GetWorkerSpecialtyById(int id);
        public Task<List<GetWorkerSpecialtyDto>> GetAllWorkerSpecialties();
        public Task<BaseResponse<string>> AddWorkerSpecialtyAsync(AddWorkerSpecialtyDto specialtyInfo);
        public Task<BaseResponse<string>> UpdateWorkerSpecialtyAsync(UpdateWorkerSpecialtyDto specialtyInfo);
        public Task<BaseResponse<string>> DeleteWorkerSpecialtyAsync(int id);
    }
}
