using ConstructionManagementAssistant.Core.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagementAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentClassificationsController(IUnitOfWork _unitOfWork) : ControllerBase
    {
       
        [HttpPost("{type}")]
        public async Task<IActionResult> CreateAsync([FromRoute] string type)
        {
            var response = await _unitOfWork.DocumentClassifications.CreateAsync(type);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var response = await _unitOfWork.DocumentClassifications.GetAsync(id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _unitOfWork.DocumentClassifications.GetAllAsync();
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] DocumentClassification type)
        {
            var response = await _unitOfWork.DocumentClassifications.UpdateAsync(type);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var response = await _unitOfWork.DocumentClassifications.DeleteAsync(id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
