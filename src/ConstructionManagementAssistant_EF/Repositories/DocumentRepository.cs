
using Azure.Core;
using ConstructionManagementAssistant.Core.Entites;

namespace ConstructionManagementAssistant.EF.Repositories
{
    public class DocumentRepository(AppDbContext _context, ILogger<DocumentRepository> _logger, Supabase.Client supabase)
                        : BaseRepository<Documnet>(_context), IDocumentRepository
    {
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

        public Task<Documnet> GetDocumentByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Documnet>> GetDocumentsByProjectIdAsync(int projectId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null, int? ClassificationId = null)
        {
            throw new NotImplementedException();
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
