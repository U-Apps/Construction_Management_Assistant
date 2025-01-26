using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Entites;
using ConstructionManagementAssistant_Core.Models.Response;

namespace ConstructionManagementAssistant_Core.Interfaces
{
    public interface ISiteEngineerRepository : IBaseRepository<SiteEngineer>
    {
        public Task<GetSiteEngineerDto> GetSiteEngineerById(int id);
        public Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(int pageNumber = 1, int pageSize = 10);
        public Task<BaseResponse<string>> AddSiteEngineerAsync(AddSiteEngineerDto siteEngineerDto);
        public Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto);
        public Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id);
    }
}
