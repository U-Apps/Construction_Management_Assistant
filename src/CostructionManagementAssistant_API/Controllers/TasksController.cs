using Microsoft.AspNetCore.Authorization;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]
public class TasksController(IUnitOfWork _unitOfWork) : ControllerBase
{
    /// <summary>
    /// إضافة مهمة جديدة
    /// </summary>
    /// <param name="addTaskDto">تفاصيل المهمة</param>
    [HttpPost(SystemApiRouts.Tasks.AddTask)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddTask([FromBody] AddTaskDto addTaskDto)
    {
        var response = await _unitOfWork.Tasks.AddTaskAsync(addTaskDto);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    /// <summary>
    /// حذف مهمة
    /// </summary>
    /// <param name="Id">معرف المهمة</param>
    /// <returns>Response message</returns>
    [HttpDelete(SystemApiRouts.Tasks.DeleteTask)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteTask(int Id)
    {
        var response = await _unitOfWork.Tasks.DeleteTaskAsync(Id);

        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    /// <summary>
    /// الحصول على جميع المهام
    /// </summary>
    /// <param name="pageNumber">رقم الصفحة</param>
    /// <param name="pageSize">حجم الصفحة</param>
    /// <param name="searchTerm">مصطلح البحث</param>
    /// <returns>قائمة المهام</returns>
    [HttpGet(SystemApiRouts.Tasks.GetAllTasks)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetTaskDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllTasks(int stageId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
    {
        var result = await _unitOfWork.Tasks.GetAllTasks(stageId, pageNumber, pageSize, searchTerm);
        if (result.Items == null || result.Items.Count == 0)
        {
            return NotFound(new BaseResponse<PagedResult<GetTaskDto>>
            {
                Success = false,
                Message = "لم يتم العثور على المهام",
            });
        }

        return Ok(new BaseResponse<PagedResult<GetTaskDto>>
        {
            Success = true,
            Message = "تم جلب المهام بنجاح",
            Data = result,
        });
    }

    /// <summary>
    /// الحصول على المهمة بواسطة المعرف
    /// </summary>
    /// <param name="Id">معرف المهمة</param>
    /// <returns>تفاصيل المهمة</returns>
    [HttpGet(SystemApiRouts.Tasks.GetTaskById)]
    [ProducesResponseType(typeof(BaseResponse<GetTaskDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetTaskDetailsDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetTaskById(int Id)
    {
        var result = await _unitOfWork.Tasks.GetTaskById(Id);
        if (result is null)
            return NotFound(new BaseResponse<GetTaskDetailsDto>()
            {
                Success = false,
                Message = "لا يوجد مهمة بهذا المعرف"
            });

        return Ok(new BaseResponse<GetTaskDetailsDto>()
        {
            Success = true,
            Message = "تم جلب المهمة بنجاح",
            Data = result
        });
    }

    /// <summary>
    /// تحديث مهمة
    /// </summary>
    /// <param name="updateTaskDto">تفاصيل المهمة</param>
    [HttpPut(SystemApiRouts.Tasks.UpdateTask)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateTask([FromBody] UpdateTaskDto updateTaskDto)
    {
        var response = await _unitOfWork.Tasks.UpdateTaskAsync(updateTaskDto);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [HttpPut(SystemApiRouts.Tasks.CompleteTask)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CompleteTask(int Id)
    {
        var response = await _unitOfWork.Tasks.CompleteTaskAsync(Id);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }




    [HttpPut(SystemApiRouts.Tasks.UnCheckTask)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UnCheckTask(int Id)
    {
        var response = await _unitOfWork.Tasks.CompleteTaskAsync(Id);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    /// <summary>
    /// الحصول على المهام القادمة
    /// </summary>
    /// <param name="daysAhead">عدد الأيام القادمة (الافتراضي 7 أيام)</param>
    /// <returns>قائمة المهام القادمة</returns>
    [HttpGet(SystemApiRouts.Tasks.GetUpcomingTasks)]
    [ProducesResponseType(typeof(IEnumerable<GetUpcomingTaskDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUpcomingTasks([FromQuery] int daysAhead = 7)
    {
        var upcomingTasks = await _unitOfWork.Tasks.GetUpcomingTasksAsync(daysAhead);
        return Ok(upcomingTasks);
    }
}
