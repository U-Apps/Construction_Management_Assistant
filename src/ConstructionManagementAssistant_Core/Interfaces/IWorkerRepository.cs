using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IWorkerRepository : IBaseRepository<Worker>
    {
        Task<PagedResult<GetWorkerDto>> GetAllWorkers(
            string userId,
            int pageNumber,
            int pageSize,
            string? searchTerm = null,
            bool? isAvailable = null);
        Task<List<WorkerNameDto>> GetWorkersNames(string userId);

        Task<WorkerDetailsDto?> GetWorkerById(int id);
        public Task<BaseResponse<string>> AddWorkerAsync(string userId, AddWorkerDto workerInfo);
        public Task<BaseResponse<string>> UpdateWorkerAsync(UpdateWorkerDto workerInfo);
        public Task<BaseResponse<string>> DeleteWorkerAsync(int id);
    }
}
