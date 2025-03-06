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

        /// <summary>
        /// حذف مرحلة
        /// </summary>
        /// <param name="Id">معرف المرحلة</param>
        /// <returns>Response message</returns>
        [HttpDelete(SystemApiRouts.Stage.DeleteStage)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(BaseResponse<string>), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStage(int Id)
        {
            var response = await _unitOfWork.Stages.DeleteStageAsync(Id);

            if (!response.Success)
                return NotFound(response);
            return Ok(response);
        }
    }
}
