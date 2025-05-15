namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
public class EquipmentAssignmentController(IUnitOfWork _unitOfWork) : ControllerBase
{
    /// <summary>
    /// Assigns a piece of equipment to a project.
    /// </summary>
    /// <param name="dto">The assignment details including equipment ID, project ID, and expected return date.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a success message if the assignment is successful,
    /// or <see cref="BadRequestObjectResult"/> with an error message if the assignment fails.
    /// </returns>
    /// <response code="200">Assignment was successful.</response>
    /// <response code="400">Assignment failed due to invalid data or business rules.</response>
    [HttpPost(SystemApiRouts.EquipmentAssignments.Assign)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> AssignEquipmentToProject([FromBody] AssignEquipmentDto dto)
    {
        var result = await _unitOfWork.EquipmentAssignments.AssignEquipmentToProjectAsync(
            dto.EquipmentId, dto.ProjectId, dto.ExpectedReturnDate);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Unassigns a piece of equipment from a project.
    /// </summary>
    /// <param name="assignmentId">The unique identifier of the equipment assignment to remove.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a success message if the unassignment is successful,
    /// or <see cref="BadRequestObjectResult"/> with an error message if the unassignment fails.
    /// </returns>
    /// <response code="200">Unassignment was successful.</response>
    /// <response code="400">Unassignment failed due to invalid assignment ID or business rules.</response>
    [HttpDelete(SystemApiRouts.EquipmentAssignments.Unassign)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UnassignEquipmentFromProject(int assignmentId)
    {
        var result = await _unitOfWork.EquipmentAssignments.UnassignEquipmentFromProjectAsync(assignmentId);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all equipment assignments for a specific equipment item.
    /// </summary>
    /// <param name="equipmentId">The unique identifier of the equipment.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of equipment assignments for the specified equipment.
    /// </returns>
    /// <response code="200">Returns the list of assignments for the equipment.</response>
    [HttpGet(SystemApiRouts.EquipmentAssignments.GetByEquipment)]
    [ProducesResponseType(typeof(List<GetEquipmentAssignmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAssignmentsByEquipmentId(int equipmentId)
    {
        var result = await _unitOfWork.EquipmentAssignments.GetAssignmentsByEquipmentIdAsync(equipmentId);
        return Ok(result);
    }

    /// <summary>
    /// Retrieves all equipment assignments for a specific project.
    /// </summary>
    /// <param name="projectId">The unique identifier of the project.</param>
    /// <returns>
    /// Returns <see cref="OkObjectResult"/> with a list of equipment assignments for the specified project.
    /// </returns>
    /// <response code="200">Returns the list of assignments for the project.</response>
    [HttpGet(SystemApiRouts.EquipmentAssignments.GetByProject)]
    [ProducesResponseType(typeof(List<GetEquipmentAssignmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAssignmentsByProjectId(int projectId)
    {
        var result = await _unitOfWork.EquipmentAssignments.GetAssignmentsByProjectIdAsync(projectId);
        return Ok(result);
    }
}
