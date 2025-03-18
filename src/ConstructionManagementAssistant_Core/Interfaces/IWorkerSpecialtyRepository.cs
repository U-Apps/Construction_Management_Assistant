using ConstructionManagementAssistant.Core.DTOs;
using ConstructionManagementAssistant.Core.Entites;
using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
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
