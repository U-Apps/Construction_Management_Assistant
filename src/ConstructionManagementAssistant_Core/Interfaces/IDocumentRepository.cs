using ConstructionManagementAssistant.Core.Models.Response;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IDocumentRepository
    {
        /// <summary>
        /// Get document details by document id.
        /// </summary>
        Task<DocumentResponse?> GetDocumentByIdAsync(Guid id);

        /// <summary>
        /// Get paged documents by project id.
        /// </summary>
        Task<PagedResult<DocumentResponse>> GetAllDocumentsAsync(
            int? projectId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null);

        /// <summary>
        /// Get all documents by task id.
        /// </summary>
        Task<List<DocumentResponse>> GetAllDocumentsByTaskIdAsync(int taskId);

        /// <summary>
        /// Add a new document (file upload).
        /// </summary>
        Task<BaseResponse<string>> UploadDocumentToProjectAsync(int projectId, UploadFileRequest document);

        /// <summary>
        /// Upload a document and associate it with a task.
        /// </summary>
        Task<BaseResponse<string>> UploadDocumentToTaskAsync(int taskId, UploadFileRequest document);

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
