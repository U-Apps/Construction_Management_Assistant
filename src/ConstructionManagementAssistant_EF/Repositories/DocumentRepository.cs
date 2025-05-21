namespace ConstructionManagementAssistant.EF.Repositories
{
    public class DocumentRepository(AppDbContext _context, ILogger<DocumentRepository> _logger, Supabase.Client supabase)
            : BaseRepository<Documnet>(_context), IDocumentRepository
    {
        private const string StoragePath = @"https://efpizvhwkfiqsrhpflcn.supabase.co/storage/v1/object/public/";

        public async Task<BaseResponse<string>> UploadDocumentAsync(UploadFileRequest document)
        {
            if (document == null || document.File == null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid request",
                    Errors = new List<string> { "File is required." }
                };
            }

            _logger.LogInformation("Adding document: {DocumentName}", document.File.FileName);
            var doc = document.ToDocument();

            try
            {
                // Check project status before uploading
                var project = await _context.Projects.FindAsync(document.ProjectId);
                if (project == null)
                {
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "Project not found",
                        Errors = new List<string> { "Invalid project ID." }
                    };
                }
                if (project.Status == ProjectStatus.Pending || project.Status == ProjectStatus.Cancelled)
                {
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "Cannot upload documents to a pending or canceled project.",
                        Errors = new List<string> { "Project status does not allow document uploads." }
                    };
                }

                using var memoryStream = new MemoryStream();
                await document.File.CopyToAsync(memoryStream);
                var lastIndexOfDot = document.File.FileName.LastIndexOf('.');

                string extension = document.File.FileName.Substring(lastIndexOfDot + 1);

                var path = await supabase.Storage.From("documents").Upload(
                    memoryStream.ToArray(),
                    $"{doc.Id}.{extension}");
                if (string.IsNullOrEmpty(path))
                {
                    _logger.LogError("Failed to upload document to storage.");
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Errors = ["Failed to upload document to storage."],
                        Message = "Unknown error occurred while uploading file"
                    };
                }
                doc.Path = StoragePath + path;
                doc.FileType = extension;
                await AddAsync(doc);
                await _context.SaveChangesAsync();
                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "Document uploaded successfully",
                };
            }
            catch (Exception e)
            {
                _logger.LogError("{message} -- {stacktrace}", e.Message, e.StackTrace);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Failed to upload document",
                    Errors = new List<string> { e.Message }
                };
            }
        }

        public async Task<BaseResponse<string>> DeleteDocumentAsync(Guid id)
        {
            if (id == Guid.Empty)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid document id"
                };
            }

            var doc = await GetByIdAsync(id);
            if (doc is null)
            {
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "المستند غير موجود"
                };
            }

            Delete(doc);
            await _context.SaveChangesAsync();

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم حذف المستند بنجاح"
            };
        }

        public async Task<DocumentDetailsResponse?> GetDocumentByIdAsync(Guid id)
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
        public async Task<PagedResult<DocumentResponse>> GetAllDocumentsAsync(
            int? projectId, int pageNumber = 1, int pageSize = 10, string? searchTerm = null)
        {
            Expression<Func<Documnet, bool>> filter = x => true;

            if (projectId.HasValue)
                filter = filter.AndAlso(d => d.ProjectId == projectId.Value);

            // Removed taskId filtering

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

        public async Task<List<DocumentResponse>> GetAllDocumentsByTaskIdAsync(int taskId)
        {
            var docs = await _context.Documnets
                .Where(d => d.TaskId == taskId)
                .OrderByDescending(d => d.CreatedDate)
                .Select(DocumentProfile.ToDocumentResponse())
                .ToListAsync();

            return docs;
        }

        public async Task<BaseResponse<string>> UpdateDocumentAsync(UpdateDocumentRequest payload)
        {
            if (payload == null || payload.Id == Guid.Empty)
            {
                _logger.LogWarning("Invalid update payload.");
                return new BaseResponse<string> { Success = false, Message = "Invalid document update request" };
            }

            var doc = await GetByIdAsync(payload.Id);
            if (doc is null)
            {
                _logger.LogWarning("Document with ID: {Id} not found", payload.Id);
                return new BaseResponse<string> { Success = false, Message = "المستند غير موجود" };
            }

            doc.Name = payload.Name?.Trim();
            doc.Description = payload.Description?.Trim();
            await _context.SaveChangesAsync();

            _logger.LogInformation("Document updated successfully: {Id}", payload.Id);

            return new BaseResponse<string>
            {
                Success = true,
                Message = "تم تحديث المستند بنجاح"
            };
        }
    }
}
