using Microsoft.AspNetCore.Authorization;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]

public class ClientsController(IUnitOfWork _unitOfWork) : ControllerBase
{

    #region Get Methods

    /// <summary>
    /// الحصول على جميع العملاء
    /// </summary>
    /// <param name="pageNumber">رقم الصفحة</param>
    /// <param name="pageSize">حجم الصفحة</param>
    /// <param name="searchTerm">نص البحث, اختياري</param>
    /// <param name="clientType">نوع العميل, اختياري</param>
    /// <remarks>
    /// سيتم جلب العملاء الذين تحتوي اسماءهم او اي حقل من حقولهم عل النص البحثي في حالة ارفاقه ومن النوع المحدد
    /// <br/>
    /// في حالة لم يتم تحديد نص بحثي او نوع العميل سيم الجلب حسب الصفحات 
    /// <br/>
    /// ClientType Enum Values:
    /// <br/>
    /// 1 - individual (فرد)
    /// <br/>
    /// 2 - Company (شركة)       
    /// </remarks>
    /// <returns>قائمة العملاء</returns>
    [HttpGet(SystemApiRouts.Clients.GetAllCleint)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetClientDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllClients(
        int pageNumber = 1,
        [Range(1, 50)] int pageSize = 10,
        string? searchTerm = null,
        ClientType? clientType = null)
    {
        var user = User.Identity.Name;

        var result = await _unitOfWork.Clients.GetAllClients(pageNumber, pageSize, searchTerm, clientType);
        if (result.Items == null || result.Items.Count == 0)
        {
            return NotFound(new BaseResponse<PagedResult<GetClientDto>>
            {
                Success = false,
                Message = "لم يتم العثور على العملاء",
            });
        }

        return Ok(new BaseResponse<PagedResult<GetClientDto>>
        {
            Success = true,
            Message = "تم جلب العملاء بنجاح",
            Data = result,
        });
    }



    /// <summary>
    /// الحصول على أسماء جميع العملاء
    /// </summary>
    [HttpGet(SystemApiRouts.Clients.GetClientNames)]
    [ProducesResponseType(typeof(BaseResponse<List<ClientNameDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientNames()
    {
        var result = await _unitOfWork.Clients.GetClientsNames();
        return Ok(new BaseResponse<List<ClientNameDto>>
        {
            Success = true,
            Message = "تم جلب أسماء العملاء بنجاح",
            Data = result
        });
    }


    /// <summary>
    /// الحصول على عميل بواسطة المعرف
    /// </summary>
    /// <param name="Id">معرف العميل</param>
    /// <returns>تفاصيل العميل</returns>
    [HttpGet(SystemApiRouts.Clients.GetClientById)]
    [ProducesResponseType(typeof(BaseResponse<ClientDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<ClientDetailsDto>), StatusCodes.Status404NotFound)]

    public async Task<IActionResult> GetClientById(int Id)
    {
        var result = await _unitOfWork.Clients.GetClientById(Id);
        if (result is null)
            return NotFound(new BaseResponse<ClientDetailsDto>()
            {
                Success = false,
                Message = "لا يوجد عميل بهذا المعرف"
            });

        return Ok(new BaseResponse<ClientDetailsDto>()
        {
            Success = true,
            Message = "تم جلب العميل بنجاح",
            Data = result
        });
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
    [HttpPost(SystemApiRouts.Clients.AddClient)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateClient(AddClientDto client)
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
    [HttpPut(SystemApiRouts.Clients.UpdateClient)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateClient(UpdateClientDto client)
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
    [HttpDelete(SystemApiRouts.Clients.DeleteClient)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteClient(int Id)
    {
        var result = await _unitOfWork.Clients.DeleteClientAsync(Id);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion
}
