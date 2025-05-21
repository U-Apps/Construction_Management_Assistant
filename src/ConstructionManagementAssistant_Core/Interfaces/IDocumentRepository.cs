using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IDocumentRepository
    {
        /// <summary>
        /// Get document details by document id.
        /// </summary>
        Task<DocumentDetailsResponse?> GetDocumentByIdAsync(Guid id);

        /// <summary>
        /// Get paged documents by project id and optional task id.
        /// </summary>
        Task<PagedResult<DocumentResponse>> GetAllDocumentsAsync(
            int? projectId, int? taskId = null, int pageNumber = 1, int pageSize = 10, string? searchTerm = null);

        /// <summary>
        /// Add a new document (file upload).
        /// </summary>
        Task<BaseResponse<string>> UploadDocumentAsync(UploadFileRequest document);

        /// <summary>
        /// Update document metadata (name, description).
        /// </summary>
        Task<BaseResponse<string>> UpdateDocumentAsync(UpdateDocumentRequest payload);

        /// <summary>
        /// Delete a document by id.
        /// </summary>
        Task<BaseResponse<string>> DeleteDocumentAsync(Guid id);
    }
}
