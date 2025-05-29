using Microsoft.AspNetCore.Authorization;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]

public class StagesController(IUnitOfWork _unitOfWork) : ControllerBase
{
    /// <summary>
    /// اضافة مرحلة جديدة
    /// </summary>
    /// <param name="addStageDto">تفاصيل المرحلة</param>
    [HttpPost(SystemApiRouts.Stages.AddStage)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AddStage([FromBody] AddStageDto addStageDto)
    {
        var response = await _unitOfWork.Stages.AddStageAsync(addStageDto);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    /// <summary>
    /// حذف مرحلة
    /// </summary>
    /// <param name="Id">معرف المرحلة</param>
    /// <returns>Response message</returns>
    [HttpDelete(SystemApiRouts.Stages.DeleteStage)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteStage(int Id)
    {
        var response = await _unitOfWork.Stages.DeleteStageAsync(Id);

        if (!response.Success)
            return NotFound(response);
        return Ok(response);
    }

    /// <summary>
    /// الحصول على جميع المراحل
    /// </summary>
    /// <param name="projectId">معرف المشروع, الزامي</param>
    /// <param name="pageNumber">رقم الصفحة</param>
    /// <param name="pageSize">حجم الصفحة</param>
    /// <returns>قائمة المراحل</returns>
    [HttpGet(SystemApiRouts.Stages.GetAllStages)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetStageDto>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAllStages([Required] int projectId, int pageNumber = 1, int pageSize = 10)
    {
        var result = await _unitOfWork.Stages.GetStagesByProjectIdAsync(projectId, null, null, null, pageNumber, pageSize);
        if (result.Items == null || result.Items.Count == 0)
        {
            return NotFound(new BaseResponse<PagedResult<GetStageDto>>
            {
                Success = false,
                Message = "لم يتم العثور على المراحل",
            });
        }

        return Ok(new BaseResponse<PagedResult<GetStageDto>>
        {
            Success = true,
            Message = "تم جلب المراحل بنجاح",
            Data = result,
        });
    }

    /// <summary>
    /// الحصول على المرحلة بواسطة المعرف
    /// </summary>
    /// <param name="Id">معرف المرحلة</param>
    /// <returns>تفاصيل المرحلة</returns>
    [HttpGet(SystemApiRouts.Stages.GetStageById)]
    [ProducesResponseType(typeof(BaseResponse<GetClientDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetClientDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetStageById(int Id)
    {
        var result = await _unitOfWork.Stages.GetStageByIdAsync(Id);
        if (result is null)
            return NotFound(new BaseResponse<GetStageDetailsDto>()
            {
                Success = false,
                Message = "لا يوجد مرحلة بهذا المعرف"
            });

        return Ok(new BaseResponse<GetStageDetailsDto>()
        {
            Success = true,
            Message = "تم جلب المرحلة بنجاح",
            Data = result
        });
    }

    /// <summary>
    /// تحديث مرحلة
    /// </summary>
    /// <param name="updateStageDto">تفاصيل المرحلة</param>
    [HttpPut(SystemApiRouts.Stages.UpdateStage)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateStage([FromBody] UpdateStageDto updateStageDto)
    {
        var response = await _unitOfWork.Stages.UpdateStageAsync(updateStageDto);

        if (!response.Success)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
}
