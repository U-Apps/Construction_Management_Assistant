using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Models.Response;

namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IWorkerRepository : IBaseRepository<Worker>
    {
        Task<PagedResult<GetWorkerDto>> GetAllWorkers(
            int pageNumber,
            int pageSize,
            string? searchTerm = null,
            bool? isAvailable = null);
        Task<WorkerDetailsDto> GetWorkerById(int id);
        public Task<BaseResponse<string>> AddWorkerAsync(AddWorkerDto workerInfo);
        public Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerInfo);
        public Task<BaseResponse<string>> DeleteWorkerAsync(int id);
    }
}
