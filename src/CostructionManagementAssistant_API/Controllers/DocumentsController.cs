using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace ConstructionManagementAssistant.API.Controllers;


[ApiController]
[Authorize]
public class DocumentsController(IUnitOfWork _unitOfWork) : ControllerBase
{
    #region 1. GET Methods

    /// <summary>
    /// Retrieves all documents, optionally filtered by project, with pagination and search.
    /// </summary>
    /// <param name="projectId">Optional project ID to filter documents.</param>
    /// <param name="pageNumber">Page number for pagination (default: 1).</param>
    /// <param name="pageSize">Page size for pagination (default: 10, min: 10, max: 50).</param>
    /// <param name="searchTerm">Optional search term for document name or description.</param>
    /// <returns>Paged list of documents or not found response.</returns>
    [HttpGet(SystemApiRouts.Documents.GetAllDocuments)]
    public async Task<IActionResult> GetAllDocuments(
        [FromQuery] int? projectId = null,
        [FromQuery] int pageNumber = 1,
        [FromQuery, Range(10, 50)] int pageSize = 10,
        [FromQuery] string? searchTerm = null)
    {

        var userId = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
        var belongToUserId = User.Claims.FirstOrDefault(c => c.Type == "BelongToUserId")?.Value;
        if (!string.IsNullOrEmpty(belongToUserId))
        {
            userId = belongToUserId;
        }


        var result = await _unitOfWork.Documents.GetAllDocumentsAsync(userId, projectId, pageNumber, pageSize, searchTerm);
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

    /// <summary>
    /// Retrieves a document by its unique identifier.
    /// </summary>
    /// <param name="id">Document unique identifier (GUID).</param>
    /// <returns>Document details or not found response.</returns>
    [HttpGet(SystemApiRouts.Documents.GetDocumentById)]
    public async Task<IActionResult> GetDocumentById([FromRoute] Guid id)
    {
        var result = await _unitOfWork.Documents.GetDocumentByIdAsync(id);
        if (result is null)
        {
            return NotFound(new BaseResponse<DocumentResponse>
            {
                Success = false,
                Message = "لا يوجد مستند بهذا المعرف"
            });
        }

        return Ok(new BaseResponse<DocumentResponse>
        {
            Success = true,
            Message = "تم جلب المستند بنجاح",
            Data = result
        });
    }

    /// <summary>
    /// Retrieves all documents associated with a specific task.
    /// </summary>
    /// <param name="taskId">Task identifier.</param>
    /// <returns>List of documents for the task or not found response.</returns>
    [HttpGet(SystemApiRouts.Documents.GetAllDocumentsByTaskId)]
    public async Task<IActionResult> GetAllDocumentsByTaskId([FromRoute] int taskId)
    {
        var result = await _unitOfWork.Documents.GetAllDocumentsByTaskIdAsync(taskId);
        if (result == null || result.Count == 0)
        {
            return NotFound(new BaseResponse<List<DocumentResponse>>
            {
                Success = false,
                Message = "لم يتم العثور على مستندات لهذه المهمة"
            });
        }

        return Ok(new BaseResponse<List<DocumentResponse>>
        {
            Success = true,
            Message = "تم جلب المستندات بنجاح",
            Data = result
        });
    }

    #endregion

    #region 2. POST Methods

    /// <summary>
    /// Uploads a document and associates it with a project.
    /// </summary>
    /// <param name="projectId">Project identifier.</param>
    /// <param name="document">Document upload request.</param>
    /// <returns>Result of the upload operation.</returns>
    [HttpPost(SystemApiRouts.Documents.UploadDocumentToProject)]
    public async Task<IActionResult> UploadDocumentToProject(
        [FromRoute] int projectId,
        [FromForm] UploadFileRequest document)
    {
        var result = await _unitOfWork.Documents.UploadDocumentToProjectAsync(projectId, document);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    /// <summary>
    /// Uploads a document and associates it with a task.
    /// </summary>
    /// <param name="taskId">Task identifier.</param>
    /// <param name="document">Document upload request.</param>
    /// <returns>Result of the upload operation.</returns>
    [HttpPost(SystemApiRouts.Documents.UploadDocumentToTask)]
    public async Task<IActionResult> UploadDocumentToTask(
        [FromRoute] int taskId,
        [FromForm] UploadFileRequest document)
    {
        var result = await _unitOfWork.Documents.UploadDocumentToTaskAsync(taskId, document);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region 3. PUT Methods

    /// <summary>
    /// Updates document metadata such as name and description.
    /// </summary>
    /// <param name="payload">Update document request payload.</param>
    /// <returns>Result of the update operation.</returns>
    [HttpPut(SystemApiRouts.Documents.UpdateDocument)]
    public async Task<IActionResult> UpdateDocument([FromBody] UpdateDocumentRequest payload)
    {
        var result = await _unitOfWork.Documents.UpdateDocumentAsync(payload);
        if (!result.Success)
            return BadRequest(result);
        return Ok(result);
    }

    #endregion

    #region 4. DELETE Methods

    /// <summary>
    /// Deletes a document by its unique identifier.
    /// </summary>
    /// <param name="id">Document unique identifier (GUID).</param>
    /// <returns>Result of the delete operation.</returns>
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

    #endregion
}
