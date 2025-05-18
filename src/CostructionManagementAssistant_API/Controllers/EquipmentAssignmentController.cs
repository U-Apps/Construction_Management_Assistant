namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
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
    /// <response code="400">Reservation failed due to invalid data or business rules.</response>
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
    /// Removes a reservation for a piece of equipment from a project.
    /// </summary>
    /// <param name="reservationId">The unique identifier of the equipment reservation to remove.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a success message if the removal is successful,
    /// or <see cref="BadRequestObjectResult"/> with an error message if the removal fails.
    /// </returns>
    /// <response code="200">Removal was successful.</response>
    /// <response code="400">Removal failed due to invalid reservation ID or business rules.</response>
    [HttpDelete(SystemApiRouts.EquipmentReservations.RemoveReservation)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> RemoveEquipmentReservation(int reservationId)
    {
        var result = await _unitOfWork.EquipmentReservations.RemoveEquipmentReservationAsync(reservationId);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all equipment reservations.
    /// </summary>
    /// <returns>Returns a list of all equipment reservations.</returns>
    [HttpGet(SystemApiRouts.EquipmentReservations.GetAll)]
    [ProducesResponseType(typeof(List<GetEquipmentReservationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAllReservations()
    {
        var result = await _unitOfWork.EquipmentReservations.GetAllEquipmentReservationsAsync();
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all equipment reservations for a specific equipment item.
    /// </summary>
    /// <param name="equipmentId">The unique identifier of the equipment.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of equipment reservations for the specified equipment.
    /// </returns>
    /// <response code="200">Returns the list of reservations for the equipment.</response>
    [HttpGet(SystemApiRouts.EquipmentReservations.GetByEquipment)]
    [ProducesResponseType(typeof(List<GetEquipmentReservationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReservationsByEquipmentId(int equipmentId)
    {
        var result = await _unitOfWork.EquipmentReservations.GetEquipmentReservationsByEquipmentIdAsync(equipmentId);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all equipment reservations for a specific project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of equipment reservations for the specified project.
    /// </returns>
    /// <response code="200">Returns the list of reservations for the project.</response>
    [HttpGet(SystemApiRouts.EquipmentReservations.GetByProject)]
    [ProducesResponseType(typeof(List<GetEquipmentReservationDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetReservationsByProjectId(int projectId)
    {
        var result = await _unitOfWork.EquipmentReservations.GetEquipmentReservationsByProjectIdAsync(projectId);
        return Ok(result);
    }
}
