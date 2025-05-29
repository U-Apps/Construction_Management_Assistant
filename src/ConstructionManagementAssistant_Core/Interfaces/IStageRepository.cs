using ConstructionManagementAssistant.Core.Models.Response;


namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IStageRepository : IBaseRepository<Stage>
    {
        Task<BaseResponse<string>> AddStageAsync(AddStageDto stageInfo);
        public Task<BaseResponse<string>> UpdateStageAsync(UpdateStageDto stageInfo);
        Task<BaseResponse<string>> DeleteStageAsync(int id);
        Task<PagedResult<GetStageDto>> GetStagesByProjectIdAsync(int projectId, string searchItem, DateOnly? startDateFilter, DateOnly? endDateFilter, int pageNumber = 1, int pageSize = 10);
        Task<GetStageDetailsDto> GetStageByIdAsync(int Id);

    }
}
