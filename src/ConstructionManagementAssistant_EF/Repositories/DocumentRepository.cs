
using Azure.Core;
using ConstructionManagementAssistant.Core.Entites;
using ConstructionManagementAssistant.Core.Enums;
using Supabase.Functions.Responses;

namespace ConstructionManagementAssistant.EF.Repositories
{
    public class DocumentRepository(AppDbContext _context, ILogger<DocumentRepository> _logger, Supabase.Client supabase)
                        : BaseRepository<Documnet>(_context), IDocumentRepository
    {
        private const string StoragePath = @"https://efpizvhwkfiqsrhpflcn.supabase.co/storage/v1/object/public/";
        public async Task<BaseResponse<string>> AddDocumentAsync(UploadFileRequest document)
        {
            _logger.LogInformation("Adding document: {DocumentName}", document.File.FileName);
            var doc = document.ToDocument();

            //var addedDocument = await AddAsync(doc);
            try
            {

            
                using var memoryStream = new MemoryStream();
                await document.File.CopyToAsync(memoryStream);
                var lastIndexOfDot = document.File.FileName.LastIndexOf('.');

                string extension = document.File.FileName.Substring(lastIndexOfDot + 1);

                var Path = await supabase.Storage.From("documents").Upload(
                    memoryStream.ToArray(),
                    $"{doc.Id}.{extension}");
                if (string.IsNullOrEmpty(Path))
                {
                    _logger.LogError("Failed to upload document to storage.");
                    return new BaseResponse<string>() {
                        Success = false,
                        Errors = ["Failed to upload document to storage."],
                        Message = "unknown error occured while uploading file"
                    };
                }
                doc.Path = Path;
                doc.FileType = extension;
                doc.Path = StoragePath + Path;
                await AddAsync(doc);
                await _context.SaveChangesAsync();
                return new BaseResponse<string>()
                {
                    Success = true,
                    Message = "Document uploaded successfully",
                };
            }
            catch (Exception e)
            {
                _logger.LogError("{message} -- {stacktrace}", e.Message, e.StackTrace);
                return new BaseResponse<string>()
                {
                    Success = false,
                    Message = "Failed to upload document",
                    Errors = new List<string> { e.Message }
                };
            }
        }

        public Task DeleteDocumentAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<DocumentDetailsResponse> GetDocumentByIdAsync(Guid id)
        {
            var doc = await FindWithSelectionAsync(
            selector: DocumentProfile.ToDocumentDetailsResponse(),
            criteria: d => d.Id == id);

            if (doc == null)
            {
                _logger.LogWarning("document with ID: {Id} not found", id);
                return null;
            }
            return doc;
        }

        public async Task<PagedResult<DocumentResponse>> GetDocumentsByProjectIdAsync(int projectId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null, int? ClassificationId = null)
        {
            Expression<Func<Documnet, bool>> filter = x => true;

            filter = filter.AndAlso(d => d.ProjectId == projectId);

            if (ClassificationId is not null)
                filter = filter.AndAlso(d => d.ClassificationId == ClassificationId);

            if (!string.IsNullOrEmpty(searchTerm))
            {
                filter = filter.AndAlso(d =>
                    d.Name.Contains(searchTerm) ||
                    d.Description.Contains(searchTerm));
            }


            var pagedResult = await GetPagedDataWithSelectionAsync(
                    orderBy: x => x.CreatedDate,
                    selector: DocumentProfile.ToDocumentResponse(),
                    criteria: filter,
                    pageNumber: pageNumber,
                    pageSize: pageSize);

            _logger.LogInformation("Fetched {Count} docs", pagedResult.Items.Count);

            return pagedResult;
            
        }

        public Task<IEnumerable<Documnet>> GetDocumentsByTaskIdAsync(int taskId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
        {
            throw new NotImplementedException();
        }

        public Task UpdateDocumentAsync(Documnet document)
        {
            throw new NotImplementedException();
        }
    }
}
