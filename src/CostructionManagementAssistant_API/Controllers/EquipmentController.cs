using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;


[ApiController]
[Authorize]
public class EquipmentController(IUnitOfWork _unitOfWork) : ControllerBase
{
    #region Get Methods

    /// <summary>
    /// Retrieves a paginated list of equipment, optionally filtered by search term and status.
    /// <para>
    /// <b>Note:</b> The status of each equipment item is determined automatically based on its reservation period.
    /// If the current date falls within a reservation period, the equipment status will be set to <c>Reserved</c>;
    /// otherwise, it will be <c>Available</c>.
    /// </para>
    /// </summary>
    /// <param name="pageNumber">The page number to retrieve (default is 1).</param>
    /// <param name="pageSize">The number of items per page (default is 10, max is 50).</param>
    /// <param name="searchTerm">An optional search term to filter equipment by name or other fields.</param>
    /// <param name="status">An optional equipment status to filter the results.</param>
    /// <returns>
    /// A <see cref="BaseResponse{T}"/> containing a paged result of <see cref="GetEquipmentDto"/> items.
    /// Returns 404 if no equipment is found.
    /// </returns>
    /// <response code="200">Returns the paged list of equipment.</response>
    /// <response code="404">No equipment found matching the criteria.</response>
    [HttpGet(SystemApiRouts.Equipment.GetAllEquipment)]
    [ProducesResponseType(typeof(BaseResponse<PagedResult<GetEquipmentDto>>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllEquipment(
        int pageNumber = 1,
        [Range(1, 50)] int pageSize = 10,
        string? searchTerm = null,
        EquipmentStatus? status = null)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }


        var result = await _unitOfWork.Equipment.GetAllEquipment(userId, pageNumber, pageSize, searchTerm, status);
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

    /// <summary>
    /// Retrieves the details of a specific equipment item by its identifier.
    /// <para>
    /// <b>Note:</b> The status of the equipment is determined automatically based on its reservation period.
    /// If the current date falls within a reservation period, the equipment status will be set to <c>Reserved</c>;
    /// otherwise, it will be <c>Available</c>.
    /// </para>
    /// </summary>
    /// <param name="id">The unique identifier of the equipment.</param>
    /// <returns>
    /// A <see cref="BaseResponse{T}"/> containing the equipment details.
    /// Returns 404 if the equipment is not found.
    /// </returns>
    /// <response code="200">Returns the equipment details.</response>
    /// <response code="404">No equipment found with the specified ID.</response>
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

    /// <summary>
    /// Creates a new equipment item.
    /// </summary>
    /// <param name="dto">The equipment data transfer object containing the details of the equipment to create.</param>
    /// <returns>
    /// A <see cref="BaseResponse{T}"/> indicating the result of the creation operation.
    /// </returns>
    /// <response code="200">Equipment was created successfully.</response>
    /// <response code="400">Creation failed due to invalid data or business rules.</response>
    [HttpPost(SystemApiRouts.Equipment.AddEquipment)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateEquipment(AddEquipmentDto dto)
    {
        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }


        var result = await _unitOfWork.Equipment.AddEquipmentAsync(userId, dto);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region Put Methods

    /// <summary>
    /// Updates the details of an existing equipment item.
    /// </summary>
    /// <param name="dto">The equipment data transfer object containing the updated details.</param>
    /// <returns>
    /// A <see cref="BaseResponse{T}"/> indicating the result of the update operation.
    /// </returns>
    /// <response code="200">Equipment was updated successfully.</response>
    /// <response code="400">Update failed due to invalid data or business rules.</response>
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



    #endregion

    #region Delete Methods

    /// <summary>
    /// Deletes a specific equipment item by its identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the equipment to delete.</param>
    /// <returns>
    /// A <see cref="BaseResponse{T}"/> indicating the result of the deletion operation.
    /// </returns>
    /// <response code="200">Equipment was deleted successfully.</response>
    /// <response code="400">Deletion failed due to invalid data or business rules.</response>
    /// <response code="404">No equipment found with the specified ID.</response>
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
