using ConstructionManagementAssistant.Core.Entites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagementAssistant.API.Controllers
{
    [ApiController]
    public class DocumentClassificationsController(IUnitOfWork _unitOfWork) : ControllerBase
    {
       
        [HttpPost(SystemApiRouts.DocumentClassifications.AddDocumentClassification)]
        public async Task<IActionResult> CreateAsync([FromRoute] string type)
        {
            var response = await _unitOfWork.DocumentClassifications.CreateAsync(type);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet(SystemApiRouts.DocumentClassifications.GetDocumentClassificationById)]
        public async Task<IActionResult> GetAsync(int Id)
        {
            var response = await _unitOfWork.DocumentClassifications.GetAsync(Id);
            if (!response.Success)
                return NotFound(response);

            return Ok(response);
        }

        [HttpGet(SystemApiRouts.DocumentClassifications.GetAllDocumentClassifications)]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _unitOfWork.DocumentClassifications.GetAllAsync();
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPut(SystemApiRouts.DocumentClassifications.UpdateDocumentClassification)]
        public async Task<IActionResult> UpdateAsync([FromBody] DocumentClassification type)
        {
            var response = await _unitOfWork.DocumentClassifications.UpdateAsync(type);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpDelete(SystemApiRouts.DocumentClassifications.DeleteDocumentClassification)]
        public async Task<IActionResult> DeleteAsync(int Id)
        {
            var response = await _unitOfWork.DocumentClassifications.DeleteAsync(Id);
            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
    }
}
