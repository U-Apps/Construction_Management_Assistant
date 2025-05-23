namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
public class DashboardController(IUnitOfWork unitOfWork) : ControllerBase
{

    [HttpGet(SystemApiRouts.Dashboard.GetMetrics)]
    public async Task<IActionResult> GetMetrics()
    {
        var result = new
        {
            ActiveProjects = await unitOfWork.Dashboard.GetActiveProjectsCountAsync(),
            PendingTasks = await unitOfWork.Dashboard.GetPendingTasksCountAsync(),
            Workers = await unitOfWork.Dashboard.GetWorkersCountAsync(),
            Documents = await unitOfWork.Dashboard.GetDocumentsCountAsync()
        };
        return Ok(result);
    }

    //[HttpGet(SystemApiRouts.Dashboard.GetProjectTimeline)]
    //public async Task<IActionResult> GetProjectTimeline()
    //{
    //    var timeline = await _dashboardRepository.GetProjectTimelineAsync();
    //    return Ok(timeline);
    //}

    //[HttpGet(SystemApiRouts.Dashboard.GetUpcomingTasks)]
    //public async Task<IActionResult> GetUpcomingTasks()
    //{
    //    var tasks = await _dashboardRepository.GetUpcomingTasksAsync();
    //    return Ok(tasks);
    //}
}
