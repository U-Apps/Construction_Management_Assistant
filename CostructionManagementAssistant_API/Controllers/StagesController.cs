using static ConstructionManagementAssistant_Core.DTOs.StageDtos;

namespace ConstructionManagementAssistant_API.Controllers
{
    [ApiController]
    public class StagesController(IUnitOfWork _unitOfWork) : ControllerBase
    {
        /// <summary>
        /// اضافة مرحلة جديدة
        /// </summary>
        /// <param name="addStageDto">تفاصيل المرحلة</param>
        [HttpPost(SystemApiRouts.Stage.AddStage)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddStage([FromBody] AddStageDto addStageDto)
        {
            var response = await _unitOfWork.Stages.AddStageAsync(addStageDto);

            if (!response.Success)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
