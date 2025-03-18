using ConstructionManagementAssistant.Core.DTOs;
using ConstructionManagementAssistant.Core.Entites;
using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface ISiteEngineerRepository : IBaseRepository<SiteEngineer>
    {
        public Task<GetSiteEngineerDto> GetSiteEngineerById(int id);
        public Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, bool? isAvailable = null);
        public Task<BaseResponse<string>> AddSiteEngineerAsync(AddSiteEngineerDto siteEngineerDto);
        public Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto);
        public Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id);
    }
}
