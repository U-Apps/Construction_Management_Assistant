using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConstructionManagementAssistant.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController(IUnitOfWork _unitOfWork) : ControllerBase
    {
        [HttpPost("upload")]
        public async Task<IActionResult> UploadDocument([FromForm]UploadFileRequest document)
        {
            if (document == null || document.File == null)
            {
                return BadRequest(new BaseResponse<string>()
                {
                    Success = false,
                    Message = "Invalid request",
                    Errors = new List<string> { "File is required." }
                });
            }
            var result = await _unitOfWork.Documents.AddDocumentAsync(document);
            return Ok(result);
        }
    }
}
