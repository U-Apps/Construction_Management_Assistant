using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;

namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IWorkerRepository : IBaseRepository<Worker>
    {
        public Task<BaseResponse<string>> AddWorkerAsync(AddWorkerDto workerInfo);
        public Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerInfo);
        public Task<BaseResponse<string>> DeleteWorkerAsync(int id);
        Task<PagedResult<GetWorkerDto>> GetAllWorkers(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, bool? isAvailable = null, int? SpecialtyId = null);
        Task<WorkerDetailsDto> GetWorkerById(int id);
    }
}
