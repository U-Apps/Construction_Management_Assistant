namespace ConstructionManagementAssistant.API.Controllers;

[ApiController]
public class EquipmentAssignmentController(IUnitOfWork _unitOfWork) : ControllerBase
{
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

    [HttpGet(SystemApiRouts.EquipmentAssignments.GetByEquipment)]
    [ProducesResponseType(typeof(List<GetEquipmentAssignmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAssignmentsByEquipmentId(int equipmentId)
    {
        var result = await _unitOfWork.EquipmentAssignments.GetAssignmentsByEquipmentIdAsync(equipmentId);
        return Ok(result);
    }

    [HttpGet(SystemApiRouts.EquipmentAssignments.GetByProject)]
    [ProducesResponseType(typeof(List<GetEquipmentAssignmentDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAssignmentsByProjectId(int projectId)
    {
        var result = await _unitOfWork.EquipmentAssignments.GetAssignmentsByProjectIdAsync(projectId);
        return Ok(result);
    }
}

