using ConstructionManagementAssistant.Core.DTOs.StatisticsDTO;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]
public class DashboardController(IUnitOfWork unitOfWork) : ControllerBase
{
    [HttpGet(SystemApiRouts.Dashboard.GetTeamStatistics)]
    [ProducesResponseType(typeof(TeamStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTeamStatistics()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }
        var result = await unitOfWork.Dashboard.GetTeamStatisticsAsync(userId);
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetProjectStatistics)]
    [ProducesResponseType(typeof(ProjectStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProjectStatistics()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }
        var result = await unitOfWork.Dashboard.GetProjectsStatistics(userId);
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetTaskStatistics)]
    [ProducesResponseType(typeof(TaskStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetTaskStatistics()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }
        var result = await unitOfWork.Dashboard.GetTasksStatisticsAync(userId);
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetEquipmentStatistics)]
    [ProducesResponseType(typeof(EquipmentStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetEquipmentStatistics()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }
        var result = await unitOfWork.Dashboard.GetEquipmentStatisticsAsync(userId);
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.Dashboard.GetDocumentsStatistics)]
    [ProducesResponseType(typeof(DocumentsStatisticsDto), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetDocumentsStatistics()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }
        var result = await unitOfWork.Dashboard.GetDocumentsStatisticsAsync(userId);
        return Ok(result);
    }
}
