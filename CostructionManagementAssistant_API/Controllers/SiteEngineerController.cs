using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Helper;
using System.ComponentModel.DataAnnotations;

namespace ConstructionManagementAssistant_API.Controllers
{
    [ApiController]
    public class SiteEngineerController(IUnitOfWork _unitOfWork) : ControllerBase
    {

        #region Get Methods

        /// <summary>
        /// الحصول على جميع المهندسين
        /// </summary>
        /// <param name="pageNumber">رقم الصفحة</param>
        /// <param name="pageSize">حجم الصفحة</param>
        /// <returns>قائمة المهندسين</returns>
        [HttpGet(SystemApiRouts.SiteEngineer.GetAllSiteEngineer)]
        [ProducesResponseType(typeof(BaseResponse<PagedResult<GetSiteEngineerDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<PagedResult<GetSiteEngineerDto>>>> GetAllSiteEngineers(int pageNumber = 1, [Range(1, 50)] int pageSize = 10)
        {
            var result = await _unitOfWork.SiteEngineers.GetAllSiteEngineers(pageNumber, pageSize);
            if (result.Items == null || !result.Items.Any())
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
        /// الحصول على مهندس بواسطة المعرف
        /// </summary>
        /// <param name="Id">معرف المهندس</param>
        /// <returns>تفاصيل المهندس</returns>
        [HttpGet(SystemApiRouts.SiteEngineer.GetSiteEngineerById)]
        [ProducesResponseType(typeof(BaseResponse<GetSiteEngineerDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<GetSiteEngineerDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<GetSiteEngineerDto>>> GetSiteEngineerById(int Id)
        {
            var result = await _unitOfWork.SiteEngineers.GetSiteEngineerById(Id);
            if (result is null)
                return NotFound(new BaseResponse<GetSiteEngineerDto>
                {
                    Message = "لا يوجد مهندس بهذا المعرف",
                    Success = false
                });

            return Ok(new BaseResponse<GetSiteEngineerDto>
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
        [HttpPost(SystemApiRouts.SiteEngineer.AddSiteEngineer)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponse<string>>> CreateSiteEngineer(AddSiteEngineerDto siteEngineer)
        {
            var result = await _unitOfWork.SiteEngineers.AddSiteEngineerAsync(siteEngineer);
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
        [HttpPut(SystemApiRouts.SiteEngineer.UpdateSiteEngineer)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponse<string>>> UpdateSiteEngineer(UpdateSiteEngineerDto siteEngineer)
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
        [HttpDelete(SystemApiRouts.SiteEngineer.DeleteSiteEngineer)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<string>>> DeleteSiteEngineer(int id)
        {
            var result = await _unitOfWork.SiteEngineers.DeleteSiteEngineerAsync(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        #endregion
    }
}
