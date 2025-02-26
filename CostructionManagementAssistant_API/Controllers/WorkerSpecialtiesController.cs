﻿namespace ConstructionManagementAssistant_API.Controllers;

[ApiController]
public class WorkerSpecialtiesController(IUnitOfWork _unitOfWork) : ControllerBase
{

    #region Get Methods
    /// <summary>
    /// الحصول على جميع تخصصات العامل
    /// </summary>
    /// <returns>قائمة تخصصات العامل</returns>
    [HttpGet(SystemApiRouts.WorkerSpecialty.GetAllWorkerSpecialties)]
    [ProducesResponseType(typeof(BaseResponse<GetClientDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetClientDto>), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse<List<GetWorkerSpecialtyDto>>>> GetAllWorkerSpecialties()
    {
        var result = await _unitOfWork.WorkerSpecialties.GetAllWorkerSpecialties();
        if (result == null || !result.Any())
            return NotFound(new BaseResponse<List<GetWorkerSpecialtyDto>> { Success = false, Message = "لم يتم العثور على التخصصات" });

        return Ok(new BaseResponse<List<GetWorkerSpecialtyDto>>
        {
            Success = true,
            Data = result,
            Message = "تم جلب أدوار العملاء بنجاح "
        });

    }


    /// <summary>
    /// الحصول على تخصص العامل بواسطة المعرف
    /// </summary>
    /// <param name="Id">معرف التخصص</param>
    /// <returns>اسم التخصص ورقم المعرف</returns>
    [HttpGet(SystemApiRouts.WorkerSpecialty.GetWorkerSpecialtyById)]
    [ProducesResponseType(typeof(BaseResponse<GetWorkerSpecialtyDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<GetWorkerSpecialtyDto>), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse<GetWorkerSpecialtyDto>>> GetWorkerSpecialtyById(int Id)
    {
        var result = await _unitOfWork.WorkerSpecialties.GetWorkerSpecialtyById(Id);
        if (result is null)
            return NotFound(new BaseResponse<GetWorkerSpecialtyDto>
            {
                Success = false,
                Message = "لا يوجد تخصص بهذا المعرف"
            });

        return Ok(new BaseResponse<GetWorkerSpecialtyDto>
        {
            Success = true,
            Message = "تم جلب التخصص بنجاح ",
            Data = result

        });
    }

    #endregion

    #region Add Actions

    /// <summary>
    /// انشاء تخصص عامل جديد
    /// </summary>
    /// <param name="WorkerSpecialty">بيانات التخصص</param>
    [HttpPost(SystemApiRouts.WorkerSpecialty.AddWorkerSpecialty)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<string>>> CreateWorkerSpecialty(AddWorkerSpecialtyDto WorkerSpecialty)
    {
        var result = await _unitOfWork.WorkerSpecialties.AddWorkerSpecialtyAsync(WorkerSpecialty);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);

    }

    #endregion

    #region Put Methods

    /// <summary>
    /// تحديث تخصص عامل موجود
    /// </summary>
    /// <param name="WorkerSpecialty">بيانات التخصص المحدثة</param>
    /// <returns>لا يوجد محتوى</returns>
    [HttpPut(SystemApiRouts.WorkerSpecialty.UpdateWorkerSpecialty)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<BaseResponse<string>>> UpdateWorkerSpecialty(UpdateWorkerSpecialtyDto WorkerSpecialty)
    {
        var result = await _unitOfWork.WorkerSpecialties.UpdateWorkerSpecialtyAsync(WorkerSpecialty);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region Delete Methods

    /// <summary>
    /// حذف تخصص عامل
    /// </summary>
    /// <param name="Id">معرف التخصص</param>
    /// <returns>لا يوجد محتوى</returns>
    [HttpDelete(SystemApiRouts.WorkerSpecialty.DeleteWorkerSpecialty)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<ActionResult<BaseResponse<string>>> DeleteClient(int Id)
    {
        var result = await _unitOfWork.WorkerSpecialties.DeleteWorkerSpecialtyAsync(Id);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion
}
