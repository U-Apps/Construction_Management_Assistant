using ConstructionManagementAssistant.Core.Models.Response;


namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IStageRepository : IBaseRepository<Stage>
    {
        Task<BaseResponse<string>> AddStageAsync(AddStageDto stageInfo);
        public Task<BaseResponse<string>> UpdateStageAsync(UpdateStageDto stageInfo);
        Task<BaseResponse<string>> DeleteStageAsync(int id);
        Task<PagedResult<GetAllStagesDto>> GetStagesByProjectIdAsync(int projectId, int pageNumber = 1, int pageSize = 10);
        Task<GetStageDto> GetStageByIdAsync(int Id);

    }
}
