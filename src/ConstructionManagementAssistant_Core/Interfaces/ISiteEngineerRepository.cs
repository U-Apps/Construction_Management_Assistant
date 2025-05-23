using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface ISiteEngineerRepository : IBaseRepository<SiteEngineer>
    {
        public Task<SiteEngineerDetailsDto?> GetSiteEngineerById(int id);
        public Task<PagedResult<GetSiteEngineerDto>> GetAllSiteEngineers(string userId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null, bool? isAvailable = null);
        Task<List<SiteEngineerNameDto>> GetSiteEngineersNames(string userId);

        public Task<BaseResponse<string>> AddSiteEngineerAsync(string userId, AddSiteEngineerDto siteEngineerDto);
        public Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto siteEngineerDto);
        public Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id);
    }
}
