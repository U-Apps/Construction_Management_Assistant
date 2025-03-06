using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;
using static ConstructionManagementAssistant_Core.DTOs.StageDtos;


namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface IStageRepository : IBaseRepository<Stage>
    {
        public Task<BaseResponse<string>> AddStageAsync(AddStageDto stageInfo);
    }
}
