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
        Task<Documnet> GetDocumentByIdAsync(int id);
        Task<IEnumerable<Documnet>> GetDocumentsByProjectIdAsync(int projectId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null, int? ClassificationId = null);
        Task<IEnumerable<Documnet>> GetDocumentsByTaskIdAsync(int taskId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null);
        Task<BaseResponse<string>> AddDocumentAsync(UploadFileRequest document);
        Task UpdateDocumentAsync(Documnet document);
        Task DeleteDocumentAsync(int id);
    }
}
