using ConstructionManagementAssistant.Core.Models.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.Core.Interfaces
{
    public interface IDocumentRepository
    {
        //Task<IEnumerable<Documnet>> GetAllDocumentsAsync(int pageNumber = 1, int pageSize = 10, string? searchTerm = null, int? ClassificationId = null);
        Task<DocumentDetailsResponse> GetDocumentByIdAsync(Guid id);
        Task<PagedResult<DocumentResponse>> GetDocumentsByProjectIdAsync(int projectId, int? TaskId = null, int pageNumber = 1, int pageSize = 10, string? searchTerm = null, int? ClassificationId = null);
        Task<BaseResponse<string>> AddDocumentAsync(UploadFileRequest document);
        Task<BaseResponse<string>> UpdateDocumentAsync(UpdateDocumentRequest payload);
        Task<BaseResponse<string>> DeleteDocumentAsync(Guid id);
    }
}
