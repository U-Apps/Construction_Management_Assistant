using ConstructionManagementAssistant_Core.DTOs;
using ConstructionManagementAssistant_Core.Helper;
using ConstructionManagementAssistant_Core.Interfaces;
using ConstructionManagementAssistant_Core.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagementAssistant_API.Controllers
{
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        #region Get Methods

        /// <summary>
        /// الحصول على جميع العملاء
        /// </summary>
        /// <param name="pageNumber">رقم الصفحة</param>
        /// <param name="pageSize">حجم الصفحة</param>
        /// <returns>قائمة العملاء</returns>
        [HttpGet(SystemApiRouts.Client.GetAllCleint)]
        [ProducesResponseType(typeof(BaseResponse<PagedResult<GetClientDto>>), StatusCodes.Status200OK)]
        public async Task<ActionResult<BaseResponse<PagedResult<GetClientDto>>>> GetAllClients(int pageNumber = 1, int pageSize = 10)
        {
            var result = await _unitOfWork.Clients.GetAllClients(pageNumber, pageSize);
            if (result.Items == null || !result.Items.Any())
                return NotFound(new BaseResponse<PagedResult<GetClientDto>>(null, "لم يتم العثورالعملاء", null, false));

            return Ok(new BaseResponse<PagedResult<GetClientDto>>(result, "تم جلب العملاء بنجاح "));

        }

        /// <summary>
        /// الحصول على عميل بواسطة المعرف
        /// </summary>
        /// <param name="Id">معرف العميل</param>
        /// <returns>تفاصيل العميل</returns>
        [HttpGet(SystemApiRouts.Client.GetClientById)]
        [ProducesResponseType(typeof(BaseResponse<GetClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<GetClientDto>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<GetClientDto>>> GetClientById(int Id)
        {
            var result = await _unitOfWork.Clients.GetClientById(Id);
            if (result is null)
                return NotFound(new BaseResponse<GetClientDto>(null, "لا يوجد عميل بهذا المعرف", null, false));

            return Ok(new BaseResponse<GetClientDto>(result, "تم جلب العميل بنجاح "));
        }

        /// <summary>
        /// إنشاء عميل جديد
        /// </summary>
        /// <param name="client">بيانات العميل</param>
        /// <remarks>
        /// ClientType Enum Values:
        /// 1 - individual (فرد)
        /// 2 - Company (شركة)
        /// </remarks>
        [HttpPost(SystemApiRouts.Client.AddClient)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponse<string>>> CreateClient(AddClientDto client)
        {
            var result = await _unitOfWork.Clients.AddClientAsync(client);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);

        }

        #endregion

        #region Put Methods

        /// <summary>
        /// تحديث عميل موجود
        /// </summary>
        /// <param name="client">بيانات العميل المحدثة</param>
        /// <returns>لا يوجد محتوى</returns>
        [HttpPut(SystemApiRouts.Client.UpdateClient)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BaseResponse<string>>> UpdateClient(UpdateClientDto client)
        {
            var result = await _unitOfWork.Clients.UpdateClientAsync(client);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        #endregion

        #region Delete Methods

        /// <summary>
        /// حذف عميل
        /// </summary>
        /// <param name="id">معرف العميل</param>
        /// <returns>لا يوجد محتوى</returns>
        [HttpDelete(SystemApiRouts.Client.DeleteClient)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<BaseResponse<string>>> DeleteClient(int id)
        {
            var result = await _unitOfWork.Clients.DeleteClientAsync(id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        #endregion
    }
}
