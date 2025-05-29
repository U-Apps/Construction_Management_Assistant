using ConstructionManagementAssistant.Core.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;

/// <summary>
/// API controller for managing site engineers.
/// Provides endpoints for listing, retrieving, creating, and deleting site engineers.
/// </summary>
[ApiController]
[Authorize]
public class SiteEngineerController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    /// <summary>
    /// Initializes a new instance of the <see cref="SiteEngineerController"/> class.
    /// </summary>
    /// <param name="unitOfWork">The unit of work for accessing repositories.</param>
    public SiteEngineerController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    #region Get Methods

    /// <summary>
    /// Retrieves a paged list of all site engineers for the current user.
    /// </summary>
    /// <param name="pageNumber">The page number (default is 1).</param>
    /// <param name="pageSize">The number of items per page (default is 10, max is 50).</param>
    /// <param name="searchTerm">Optional search term to filter by name, email, or phone number.</param>
    /// <param name="isAvailable">Optional filter for availability (currently not used).</param>
    /// <remarks>
    /// Returns site engineers whose fields match the search term, if provided.
    /// If no search term or availability is specified, returns paged results.
    /// </remarks>
    /// <returns>
    /// <see cref="BaseResponse{PagedResult{UserDto}}"/> containing the list of site engineers.
    /// </returns>
    [HttpGet(SystemApiRouts.SiteEngineers.GetAllSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<UserDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSiteEngineers(
        int pageNumber = 1,
        [Range(1, 50)] int pageSize = 10,
        string? searchTerm = null,
        bool? isAvailable = null)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }

        var result = await _unitOfWork.SiteEngineers.GetAllSiteEngineers(userId, pageNumber, pageSize, searchTerm);

        if (result.Data.Items == null || result.Data.Items.Count == 0)
            return NotFound(new BaseResponse<PagedResult<UserDto>>
            {
                Message = "لم يتم العثور على المهندسين",
                Success = false
            });

        return Ok(new BaseResponse<PagedResult<UserDto>>
        {
            Data = result.Data,
            Message = "تم جلب المهندسين بنجاح ",
            Success = true
        });
    }

    /// <summary>
    /// Retrieves the names and IDs of all site engineers for the current user.
    /// </summary>
    /// <returns>
    /// <see cref="BaseResponse{List{UserNameDto}}"/> containing the names and IDs of site engineers.
    /// </returns>
    [HttpGet(SystemApiRouts.SiteEngineers.GetSiteEngineerNames)]
    [ProducesResponseType(typeof(BaseResponse<List<UserNameDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSiteEngineerNames()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }

        var result = await _unitOfWork.SiteEngineers.GetSiteEngineersNames(userId);
        return Ok(new BaseResponse<List<UserNameDto>>
        {
            Success = true,
            Message = "تم جلب أسماء المهندسين بنجاح",
            Data = result
        });
    }

    /// <summary>
    /// Retrieves the details of a site engineer by their unique identifier.
    /// </summary>
    /// <param name="Id">The unique identifier of the site engineer.</param>
    /// <returns>
    /// <see cref="BaseResponse{UserDto}"/> containing the site engineer details, or an error if not found.
    /// </returns>
    [HttpGet(SystemApiRouts.SiteEngineers.GetSiteEngineerById)]
    [ProducesResponseType(typeof(BaseResponse<UserDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<UserDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSiteEngineerById(int Id)
    {
        var result = await _unitOfWork.SiteEngineers.GetSiteEngineerById(Id);
        if (result is null)
            return NotFound(new BaseResponse<UserDto>
            {
                Message = "لا يوجد مهندس بهذا المعرف",
                Success = false
            });

        return Ok(new BaseResponse<UserDto>
        {
            Data = result.Data,
            Message = "تم جلب المهندس بنجاح ",
            Success = true
        });
    }

    #endregion

    #region Post Method

    /// <summary>
    /// Creates a new site engineer.
    /// </summary>
    /// <param name="siteEngineer">The registration data for the new site engineer.</param>
    /// <returns>
    /// <see cref="BaseResponse{string}"/> indicating success or failure.
    /// </returns>
    [HttpPost(SystemApiRouts.SiteEngineers.AddSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSiteEngineer(RegisterDto siteEngineer)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }

        var result = await _unitOfWork.SiteEngineers.AddSiteEngineerAsync(userId, siteEngineer);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region Put Methods

    /// <summary>
    /// Updates an existing site engineer.
    /// </summary>
    /// <param name="siteEngineer">The updated site engineer data.</param>
    /// <returns>
    /// <see cref="BaseResponse{string}"/> indicating success or failure.
    /// </returns>
    [HttpPut(SystemApiRouts.SiteEngineers.UpdateSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateSiteEngineer(UpdateSiteEngineerDto siteEngineer)
    {
        var result = await _unitOfWork.SiteEngineers.UpdateSiteEngineerAsync(siteEngineer);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region Delete Methods

    /// <summary>
    /// Deletes a site engineer by their unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the site engineer to delete.</param>
    /// <returns>
    /// <see cref="BaseResponse{string}"/> indicating success or failure.
    /// </returns>
    [HttpDelete(SystemApiRouts.SiteEngineers.DeleteSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteSiteEngineer(int id)
    {
        var result = await _unitOfWork.SiteEngineers.DeleteSiteEngineerAsync(id);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion
}
