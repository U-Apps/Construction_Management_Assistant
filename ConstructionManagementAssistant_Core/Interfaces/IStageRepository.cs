using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;
using static ConstructionManagementAssistant_Core.DTOs.StageDtos;


namespace ConstructionManagementAssistant_Core.Interfaces
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
