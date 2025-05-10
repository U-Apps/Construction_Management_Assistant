namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
public class WorkersController(IUnitOfWork _unitOfWork) : ControllerBase
{

    #region Get Methods

    /// <summary>
    /// الحصول على جميع العمال
    /// </summary>
    /// <param name="pageNumber">رقم الصفحة</param>
    /// <param name="pageSize">حجم الصفحة</param>
    /// <param name="searchTerm">نص البحث, اختياري</param>
    /// <param name="isAvailable">التوافر, اختياري</param>
    /// <param name="SpecialtyId">معرف تخصص العامل, اختياري</param>
    /// <remarks>
    /// سيتم جلب العمال الذين تحتوي اسماءهم أو أي من حقولهم على النص البحثي في حالة ارفاقه
    /// <br/>
    /// في حالة لم يتم تحديد نص بحثي أو التوافر سيتم الجلب حسب الصفحات 
    /// </remarks>
    /// <returns>قائمة العمال</returns>
    [HttpGet(SystemApiRouts.Workers.GetAllWorkers)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetWorkerDto>>), StatusCodes.Status200OK)]
    public async Task<ActionResult<BaseResponse<PagedResult<GetWorkerDto>>>> GetAllWorkers(int pageNumber = 1,
                                                                                           [Range(1, 50)] int pageSize = 10,
                                                                                           string? searchTerm = null,
                                                                                           bool? isAvailable = null,
                                                                                           int? SpecialtyId = null)
    {
        var result = await _unitOfWork.Workers.GetAllWorkers(pageNumber, pageSize, searchTerm, isAvailable);
        if (result.Items == null || !result.Items.Any())
            return NotFound(new BaseResponse<PagedResult<GetClientDto>>
            {
                Success = false,
                Message = "لم يتم العثور على أي عمال"
            });

        return Ok(new BaseResponse<PagedResult<GetWorkerDto>>
        {
            Success = true,
            Message = "تم جلب العمال بنجاح ",
            Data = result
        });

    }


    /// <summary>
    /// الحصول على عميل بواسطة المعرف
    /// </summary>
    /// <param name="Id">معرف العميل</param>
    /// <returns>تفاصيل العميل</returns>
    [HttpGet(SystemApiRouts.Workers.GetWorkerById)]
    [ProducesResponseType(typeof(BaseResponse<WorkerDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<WorkerDetailsDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetWorkerById(int Id)
    {
        var result = await _unitOfWork.Workers.GetWorkerById(Id);
        if (result is null)
            return NotFound(new BaseResponse<WorkerDetailsDto>()
            {
                Success = false,
                Message = "لا يوجد عامل بهذا المعرف"
            });

        return Ok(new BaseResponse<WorkerDetailsDto>()
        {
            Success = true,
            Message = "تم جلب العامل بنجاح",
            Data = result
        });
    }

    #endregion

    #region Put Methods


    /// <summary>
    /// إنشاء عامل جديد
    /// </summary>
    /// <param name="workerdto">بيانات العامل</param>
    [HttpPost(SystemApiRouts.Workers.AddWorker)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<string>>> CreateWorker(AddWorkerDto workerdto)
    {
        var result = await _unitOfWork.Workers.AddWorkerAsync(workerdto);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);

    }

    #endregion

    #region Put Methods

    /// <summary>
    /// تحديث عامل موجود
    /// </summary>
    /// <param name="workerdto">بيانات العامل المحدثة</param>
    /// <returns>لا يوجد محتوى</returns>
    [HttpPut(SystemApiRouts.Workers.UpdateWorker)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<string>>> UpdateWorker(UpdateWorkerDto workerdto)
    {
        var result = await _unitOfWork.Workers.UpdateWorkerAsync(workerdto);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region Delete Methods

    /// <summary>
    /// حذف عامل
    /// </summary>
    /// <param name="id">معرف العامل</param>
    /// <returns>لا يوجد محتوى</returns>
    [HttpDelete(SystemApiRouts.Workers.DeleteWorker)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse<string>>> DeleteClient(int id)
    {
        var result = await _unitOfWork.Workers.DeleteWorkerAsync(id);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion
}
