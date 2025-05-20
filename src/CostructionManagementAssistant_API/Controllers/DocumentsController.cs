namespace ConstructionManagementAssistant.API.Controllers
{
    [ApiController]
    public class DocumentsController(IUnitOfWork _unitOfWork) : ControllerBase
    {
        [HttpPost(SystemApiRouts.Documents.UploadDocument)]
        public async Task<IActionResult> UploadDocument([FromForm] UploadFileRequest document)
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

        [HttpGet(SystemApiRouts.Documents.GetAllDocuments)]
        public async Task<IActionResult> GetAllDocs(int projectId,
                                                    int? TaskId = null,
                                                    int pageNumber = 1,
                                                    [Range(10, 50)] int pageSize = 10,
                                                    string? searchTerm = null)
        {
            var result = await _unitOfWork.Documents.GetDocumentsByProjectIdAsync(projectId, TaskId, pageNumber, pageSize, searchTerm);
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
        public async Task<IActionResult> GetDocumentById(Guid Id)
        {
            var result = await _unitOfWork.Documents.GetDocumentByIdAsync(Id);
            if (result is null)
                return NotFound(new BaseResponse<DocumentDetailsResponse>()
                {
                    Success = false,
                    Message = "لا يوجد مستند بهذا المعرف"
                });

            return Ok(new BaseResponse<DocumentDetailsResponse>()
            {
                Success = true,
                Message = "تم جلب المستند بنجاح",
                Data = result
            });
        }

        [HttpPut(SystemApiRouts.Documents.UpdateDocument)]
        public async Task<IActionResult> UpdateClient(UpdateDocumentRequest payload)
        {
            var result = await _unitOfWork.Documents.UpdateDocumentAsync(payload);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }

        [HttpDelete(SystemApiRouts.Documents.DeleteDocument)]
        public async Task<IActionResult> DeleteDocument(Guid Id)
        {
            var result = await _unitOfWork.Documents.DeleteDocumentAsync(Id);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
