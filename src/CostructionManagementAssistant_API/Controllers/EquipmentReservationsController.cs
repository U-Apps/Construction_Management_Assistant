using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
[Authorize]

public class EquipmentReservationController(IUnitOfWork _unitOfWork) : ControllerBase
{
    /// <summary>
    /// Reserves a piece of equipment for a project.
    /// </summary>
    /// <param name="dto">The reservation details including equipment ID, project ID, start date, and end date.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a success message if the reservation is successful,
    /// or <see cref="BadRequestObjectResult"/> with an error message if the reservation fails.
    /// </returns>
    /// <response code="200">Reservation was successful.</response>
    /// <response code="400">
    /// Reservation failed due to one of the following reasons:
    /// <list type="bullet">
    /// <item>Equipment does not exist.</item>
    /// <item>Project does not exist.</item>
    /// <item>There is an overlapping reservation for the equipment in the specified period.</item>
    /// </list>
    /// </response>
    [HttpPost(SystemApiRouts.EquipmentReservations.Reserve)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> ReserveEquipmentForProject([FromBody] ReserveEquipmentDto dto)
    {
        var result = await _unitOfWork.EquipmentReservations.ReserveEquipmentForProjectAsync(
            dto.EquipmentId, dto.ProjectId, dto.StartDate, dto.EndDate);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Cancels an existing equipment reservation.
    /// </summary>
    /// <param name="reservationId">The unique identifier of the equipment reservation to cancel.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a success message if the cancellation is successful,
    /// or <see cref="BadRequestObjectResult"/> with an error message if the cancellation fails.
    /// </returns>
    /// <response code="200">Cancellation was successful.</response>
    /// <response code="400">
    /// Cancellation failed due to one of the following reasons:
    /// <list type="bullet">
    /// <item>The reservation does not exist.</item>
    /// <item>The reservation is already completed and cannot be canceled.</item>
    /// </list>
    /// </response>
    [HttpDelete(SystemApiRouts.EquipmentReservations.RemoveReservation)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveEquipmentReservation(int reservationId)
    {
        var result = await _unitOfWork.EquipmentReservations.DeleteEquipmentReservationAsync(reservationId);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all equipment reservations.
    /// </summary>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of all equipment reservations.
    /// </returns>
    /// <remarks>
    /// Each reservation includes a <c>ReservationStatus</c> property, which can be:
    /// <list type="bullet">
    /// <br></br>
    ///   <item><see cref="NotStarted"/>: The reservation's start date is in the future.</item>
    /// <br></br>
    ///   
    ///   <item><see cref="Started"/>: The reservation is currently active (today is between start and end dates, inclusive).</item>
    /// <br></br>
    ///   
    ///   <item><see cref="Compoleted"/>: The reservation's end date is in the past.</item>
    /// </list>
    /// </remarks>
    /// <response code="200">Returns the list of all equipment reservations.</response>
    [HttpGet(SystemApiRouts.EquipmentReservations.GetAll)]
    [ProducesResponseType(typeof(List<GetEquipmentReservationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllReservations()
    {


        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;

        var result = await _unitOfWork.EquipmentReservations.GetAllEquipmentReservationsAsync(userId);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all reservations for a specific equipment item.
    /// </summary>
    /// <param name="equipmentId">The unique identifier of the equipment.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of reservations for the specified equipment.
    /// </returns>
    /// <remarks>
    /// Each reservation includes a <c>ReservationStatus</c> property, which can be:
    /// <list type="bullet">
    /// <br></br>
    ///   <item><see cref="NotStarted"/>: The reservation's start date is in the future.</item>
    /// <br></br>
    ///   
    ///   <item><see cref="Started"/>: The reservation is currently active (today is between start and end dates, inclusive).</item>
    /// <br></br>
    ///   
    ///   <item><see cref="Compoleted"/>: The reservation's end date is in the past.</item>
    /// <br></br>
    ///   
    /// </list>
    /// </remarks>
    /// <response code="200">Returns the list of reservations for the equipment.</response>
    [HttpGet(SystemApiRouts.EquipmentReservations.GetByEquipment)]
    [ProducesResponseType(typeof(List<GetEquipmentReservationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReservationsByEquipmentId(int equipmentId)
    {
        var result = await _unitOfWork.EquipmentReservations.GetEquipmentReservationsByEquipmentIdAsync(equipmentId);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all reservations for a specific project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of reservations for the specified project.
    /// </returns>
    /// <remarks>
    /// Each reservation includes a <c>ReservationStatus</c> property, which can be:
    /// <list type="bullet">
    /// <br></br>
    /// 
    ///   <item><see cref="NotStarted"/>: The reservation's start date is in the future.</item>
    /// <br></br>
    ///   
    ///   <item><see cref="Started"/>: The reservation is currently active (today is between start and end dates, inclusive).</item>
    /// <br></br>
    ///   
    ///   <item><see cref="Compoleted"/>: The reservation's end date is in the past.</item>
    /// <br></br>
    ///   
    /// </list>
    /// </remarks>
    /// <response code="200">Returns the list of reservations for the project.</response>
    [HttpGet(SystemApiRouts.EquipmentReservations.GetByProject)]
    [ProducesResponseType(typeof(List<GetEquipmentReservationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReservationsByProjectId(int projectId)
    {
        var result = await _unitOfWork.EquipmentReservations.GetEquipmentReservationsByProjectIdAsync(projectId);
        return Ok(result);
    }

}
