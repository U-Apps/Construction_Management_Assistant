namespace ConstructionManagementAssistant.API.Controllers;


[ApiController]
public class EquipmentController(IUnitOfWork _unitOfWork) : ControllerBase
{
    #region Get Methods

    [HttpGet(SystemApiRouts.Equipment.GetAllEquipment)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetEquipmentDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEquipment(
        int pageNumber = 1,
        [Range(1, 50)] int pageSize = 10,
        string? searchTerm = null,
        EquipmentStatus? status = null)
    {
        var result = await _unitOfWork.Equipment.GetAllEquipment(pageNumber, pageSize, searchTerm, status);
        if (result.Items == null || result.Items.Count == 0)
        {
            return NotFound(new BaseResponse<PagedResult<GetEquipmentDto>>
            {
                Success = false,
                Message = "لم يتم العثور على المعدات",
            });
        }

        return Ok(new BaseResponse<PagedResult<GetEquipmentDto>>
        {
            Success = true,
            Message = "تم جلب المعدات بنجاح",
            Data = result,
        });
    }

    [HttpGet(SystemApiRouts.Equipment.GetEquipmentById)]
    [ProducesResponseType(typeof(BaseResponse<EquipmentDetailsDto>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<EquipmentDetailsDto>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetEquipmentById(int id)
    {
        var result = await _unitOfWork.Equipment.GetEquipmentById(id);
        if (result is null)
            return NotFound(new BaseResponse<EquipmentDetailsDto>
            {
                Success = false,
                Message = "لا يوجد معدة بهذا المعرف"
            });

        return Ok(new BaseResponse<EquipmentDetailsDto>
        {
            Success = true,
            Message = "تم جلب المعدة بنجاح",
            Data = result
        });
    }


    #endregion

    #region Post Methods

    [HttpPost(SystemApiRouts.Equipment.AddEquipment)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateEquipment(AddEquipmentDto dto)
    {
        var result = await _unitOfWork.Equipment.AddEquipmentAsync(dto);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }


    #endregion

    #region Put Methods

    [HttpPut(SystemApiRouts.Equipment.UpdateEquipment)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateEquipment(UpdateEquipmentDto dto)
    {
        var result = await _unitOfWork.Equipment.UpdateEquipmentAsync(dto);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    [HttpPut(SystemApiRouts.Equipment.SetStatus)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> SetEquipmentStatus(int equipmentId, EquipmentStatus status)
    {
        var result = await _unitOfWork.Equipment.SetEquipmentStatusAsync(equipmentId, status);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region Delete Methods

    [HttpDelete(SystemApiRouts.Equipment.DeleteEquipment)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteEquipment(int id)
    {
        var result = await _unitOfWork.Equipment.DeleteEquipmentAsync(id);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion
}
