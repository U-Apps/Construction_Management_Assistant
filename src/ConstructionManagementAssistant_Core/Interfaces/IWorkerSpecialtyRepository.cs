using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IWorkerSpecialtyRepository : IBaseRepository<WorkerSpecialty>
    {
        public Task<GetWorkerSpecialtyDto?> GetWorkerSpecialtyById(int id);
        public Task<List<GetWorkerSpecialtyDto>> GetAllWorkerSpecialties(string userId);
        public Task<BaseResponse<string>> AddWorkerSpecialtyAsync(string userId, AddWorkerSpecialtyDto specialtyInfo);
        public Task<BaseResponse<string>> UpdateWorkerSpecialtyAsync(UpdateWorkerSpecialtyDto specialtyInfo);
        public Task<BaseResponse<string>> DeleteWorkerSpecialtyAsync(int id);
    }
}
