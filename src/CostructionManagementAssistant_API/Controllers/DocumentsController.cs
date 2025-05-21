namespace ConstructionManagementAssistant.API.Controllers
{
    [ApiController]
    public class DocumentsController(IUnitOfWork _unitOfWork) : ControllerBase
    {
        [HttpPost(SystemApiRouts.Documents.UploadDocument)]
        public async Task<IActionResult> UploadDocument([FromForm] UploadFileRequest document)
        {
            var result = await _unitOfWork.Documents.UploadDocumentAsync(document);
            if (!result.Success)
            {
                // File or business validation failed
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet(SystemApiRouts.Documents.GetAllDocuments)]
        public async Task<IActionResult> GetAllDocs([FromQuery] int? projectId = null,
                                                    [FromQuery] int? taskId = null,
                                                    [FromQuery] int pageNumber = 1,
                                                    [FromQuery, Range(10, 50)] int pageSize = 10,
                                                    [FromQuery] string? searchTerm = null)
        {
            var result = await _unitOfWork.Documents.GetAllDocumentsAsync(projectId, taskId, pageNumber, pageSize, searchTerm);
            if (result.Items == null || result.Items.Count == 0)
            {
                return NotFound(new BaseResponse<PagedResult<DocumentResponse>>
                {
                    Success = false,
                    Message = "لم يتم العثور على المستندات",
                });
            }

            return Ok(new BaseResponse<PagedResult<DocumentResponse>>
            {
                Success = true,
                Message = "تم جلب المستندات بنجاح",
                Data = result,
            });
        }

        [HttpGet(SystemApiRouts.Documents.GetDocumentById)]
        public async Task<IActionResult> GetDocumentById([FromRoute] Guid id)
        {
            var result = await _unitOfWork.Documents.GetDocumentByIdAsync(id);
            if (result is null)
                return NotFound(new BaseResponse<DocumentDetailsResponse>
                {
                    Success = false,
                    Message = "لا يوجد مستند بهذا المعرف"
                });

            return Ok(new BaseResponse<DocumentDetailsResponse>
            {
                Success = true,
                Message = "تم جلب المستند بنجاح",
                Data = result
            });
        }

        [HttpPut(SystemApiRouts.Documents.UpdateDocument)]
        public async Task<IActionResult> UpdateDocument([FromBody] UpdateDocumentRequest payload)
        {
            var result = await _unitOfWork.Documents.UpdateDocumentAsync(payload);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(SystemApiRouts.Documents.DeleteDocument)]
        public async Task<IActionResult> DeleteDocument([FromRoute] Guid id)
        {
            var result = await _unitOfWork.Documents.DeleteDocumentAsync(id);
            if (!result.Success)
            {
                if (result.Message == "المستند غير موجود")
                    return NotFound(result);
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
