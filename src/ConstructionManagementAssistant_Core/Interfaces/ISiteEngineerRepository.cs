using ConstructionManagementAssistant.Core.DTOs.Auth;
using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces;

public interface ISiteEngineerRepository
{
    Task<BaseResponse<UserDto?>> GetSiteEngineerById(int id);
    Task<BaseResponse<PagedResult<UserDto>>> GetAllSiteEngineers(
           string userId,
           int pageNumber = 1,
           int pageSize = 10,
           string? searchTerm = null);
    Task<List<UserNameDto>> GetSiteEngineersNames(string userId);

    Task<BaseResponse<string>> AddSiteEngineerAsync(string userId, RegisterDto registerDto);
    public Task<BaseResponse<string>> UpdateSiteEngineerAsync(UpdateSiteEngineerDto dto);
    Task<BaseResponse<string>> DeleteSiteEngineerAsync(int id);
}
