using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]
public class SiteEngineerController(IUnitOfWork _unitOfWork) : ControllerBase
{

    #region Get Methods
    /// <summary>
    /// الحصول على جميع المهندسين
    /// </summary>
    /// <param name="pageNumber">رقم الصفحة</param>
    /// <param name="pageSize">حجم الصفحة</param>
    /// <param name="searchTerm">نص البحث, اختياري</param>
    /// <param name="isAvailable">التوافر, اختياري</param>
    /// <remarks>
    /// سيتم جلب المهندسين الذين تحتوي اسماءهم أو أي من حقولهم على النص البحثي في حالة ارفاقه
    /// <br/>
    /// في حالة لم يتم تحديد نص بحثي أو التوافر سيتم الجلب حسب الصفحات 
    /// </remarks>
    /// <returns>قائمة المهندسين</returns>
    [HttpGet(SystemApiRouts.SiteEngineers.GetAllSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetSiteEngineerDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllSiteEngineers(
        int pageNumber = 1,
        [Range(1, 50)] int pageSize = 10,
        string? searchTerm = null,
        bool? isAvailable = null)
    {

        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


        var result = await _unitOfWork.SiteEngineers.GetAllSiteEngineers(userId, pageNumber, pageSize, searchTerm, isAvailable);

        if (result.Items == null || result.Items.Count == 0)
            return NotFound(new BaseResponse<PagedResult<GetSiteEngineerDto>>
            {
                Message = "لم يتم العثور على المهندسين",
                Success = false
            });

        return Ok(new BaseResponse<PagedResult<GetSiteEngineerDto>>
        {
            Data = result,
            Message = "تم جلب المهندسين بنجاح ",
            Success = true
        });
    }


    /// <summary>
    /// الحصول على أسماء جميع المهندسين
    /// </summary>
    [HttpGet(SystemApiRouts.SiteEngineers.GetSiteEngineerNames)]
    [ProducesResponseType(typeof(BaseResponse<List<SiteEngineerNameDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetSiteEngineerNames()
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


        var result = await _unitOfWork.SiteEngineers.GetSiteEngineersNames(userId);
        return Ok(new BaseResponse<List<SiteEngineerNameDto>>
        {
            Success = true,
            Message = "تم جلب أسماء المهندسين بنجاح",
            Data = result
        });
    }



    /// <summary>
    /// الحصول على مهندس بواسطة المعرف
    /// </summary>
    /// <param name="Id">معرف المهندس</param>
    /// <returns>تفاصيل المهندس</returns>
    [HttpGet(SystemApiRouts.SiteEngineers.GetSiteEngineerById)]
    [ProducesResponseType(typeof(BaseResponse<SiteEngineerDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<SiteEngineerDetailsDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetSiteEngineerById(int Id)
    {
        var result = await _unitOfWork.SiteEngineers.GetSiteEngineerById(Id);
        if (result is null)
            return NotFound(new BaseResponse<SiteEngineerDetailsDto>
            {
                Message = "لا يوجد مهندس بهذا المعرف",
                Success = false
            });

        return Ok(new BaseResponse<SiteEngineerDetailsDto>
        {
            Data = result,
            Message = "تم جلب المهندس بنجاح ",
            Success = true
        });
    }

    #endregion



    #region Post Method

    /// <summary>
    /// إنشاء مهندس جديد
    /// </summary>
    /// <param name="client">بيانات المهندس</param>
    [HttpPost(SystemApiRouts.SiteEngineers.AddSiteEngineer)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateSiteEngineer(AddSiteEngineerDto siteEngineer)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;


        var result = await _unitOfWork.SiteEngineers.AddSiteEngineerAsync(userId, siteEngineer);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);

    }

    #endregion



    #region Put Methods

    /// <summary>
    /// تحديث مهندس موجود
    /// </summary>
    /// <param name="siteEngineer">بيانات المهندس المحدثة</param>
    /// <returns>لا يوجد محتوى</returns>
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
    /// حذف مهندس
    /// </summary>
    /// <param name="id">معرف المهندس</param>
    /// <returns>لا يوجد محتوى</returns>
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
