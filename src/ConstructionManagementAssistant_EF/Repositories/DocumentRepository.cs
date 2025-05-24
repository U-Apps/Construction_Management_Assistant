namespace ConstructionManagementAssistant.EF.Repositories
{
    public class DocumentRepository(AppDbContext _context, ILogger<DocumentRepository> _logger, Supabase.Client supabase)
            : BaseRepository<Document>(_context), IDocumentRepository
    {
        private const string StoragePath = @"https://efpizvhwkfiqsrhpflcn.supabase.co/storage/v1/object/public/";

        public async Task<PagedResult<DocumentResponse>> GetAllDocumentsAsync(
            string userId,
            int? projectId,
            int pageNumber = 1,
            int pageSize = 10,
            string? searchTerm = null)
        {
            _logger.LogInformation("Fetching documents for userId: {UserId}, projectId: {ProjectId}, page: {PageNumber}, size: {PageSize}, search: {SearchTerm}",
                userId, projectId, pageNumber, pageSize, searchTerm);

            try
            {
                Expression<Func<Document, bool>> filter = x => true;
                filter = filter.AndAlso(x => x.Project.Client.UserId == int.Parse(userId));

                if (projectId.HasValue)
                    filter = filter.AndAlso(d => d.ProjectId == projectId.Value);

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

                _logger.LogInformation("Fetched {Count} documents for userId: {UserId}", pagedResult.Items.Count, userId);

                return pagedResult;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching documents for userId: {UserId}", userId);
                throw;
            }
        }

        public async Task<List<DocumentResponse>> GetAllDocumentsByTaskIdAsync(int taskId)
        {
            _logger.LogInformation("Fetching documents for taskId: {TaskId}", taskId);

            try
            {
                var docs = await _context.Documents
                    .Where(d => d.TaskId == taskId)
                    .OrderByDescending(d => d.CreatedDate)
                    .Select(DocumentProfile.ToDocumentResponse())
                    .ToListAsync();

                _logger.LogInformation("Fetched {Count} documents for taskId: {TaskId}", docs.Count, taskId);

                return docs;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching documents for taskId: {TaskId}", taskId);
                throw;
            }
        }

        public async Task<DocumentResponse?> GetDocumentByIdAsync(Guid id)
        {
            _logger.LogInformation("Fetching document by ID: {Id}", id);

            try
            {
                var doc = await FindWithSelectionAsync(
                    selector: DocumentProfile.ToDocumentResponse(),
                    criteria: d => d.Id == id);

                if (doc == null)
                {
                    _logger.LogWarning("Document with ID: {Id} not found", id);
                    return null;
                }

                _logger.LogInformation("Document with ID: {Id} fetched successfully", id);
                return doc;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching document by ID: {Id}", id);
                throw;
            }
        }

        public async Task<BaseResponse<string>> UploadDocumentToProjectAsync(int projectId, UploadFileRequest document)
        {
            _logger.LogInformation("Uploading document to projectId: {ProjectId}, file: {FileName}", projectId, document?.File?.FileName);

            if (document == null || document.File == null)
            {
                _logger.LogWarning("Invalid upload request: file is required.");
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid request",
                    Errors = new List<string> { "File is required." }
                };
            }

            var doc = document.ToDocument();
            doc.ProjectId = projectId;
            doc.TaskId = null;

            try
            {
                var project = await _context.Projects.FindAsync(projectId);
                if (project == null)
                {
                    _logger.LogWarning("Project with ID: {ProjectId} not found for document upload", projectId);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "Project not found",
                        Errors = new List<string> { "Invalid project ID." }
                    };
                }
                if (project.Status == ProjectStatus.Pending || project.Status == ProjectStatus.Cancelled)
                {
                    _logger.LogWarning("Cannot upload document to projectId: {ProjectId} with status: {Status}", projectId, project.Status);
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
                    _logger.LogError("Failed to upload document to storage for projectId: {ProjectId}", projectId);
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

                _logger.LogInformation("Document uploaded successfully to projectId: {ProjectId}, documentId: {DocumentId}", projectId, doc.Id);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "Document uploaded successfully",
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to upload document to projectId: {ProjectId}", projectId);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Failed to upload document",
                    Errors = new List<string> { e.Message }
                };
            }
        }

        public async Task<BaseResponse<string>> UploadDocumentToTaskAsync(int taskId, UploadFileRequest document)
        {
            _logger.LogInformation("Uploading document to taskId: {TaskId}, file: {FileName}", taskId, document?.File?.FileName);

            if (document == null || document.File == null)
            {
                _logger.LogWarning("Invalid upload request: file is required.");
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid request",
                    Errors = new List<string> { "File is required." }
                };
            }

            var doc = document.ToDocument();
            doc.TaskId = taskId;

            try
            {
                var task = await _context.Tasks.FindAsync(taskId);
                if (task == null)
                {
                    _logger.LogWarning("Task with ID: {TaskId} not found for document upload", taskId);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "Task not found",
                        Errors = new List<string> { "Invalid task ID." }
                    };
                }

                var stage = await _context.Stages.FindAsync(task.StageId);
                if (stage == null)
                {
                    _logger.LogWarning("Stage not found for taskId: {TaskId}", taskId);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "Stage not found for the task",
                        Errors = new List<string> { "Invalid stage for the given task." }
                    };
                }

                doc.ProjectId = stage.ProjectId;

                using var memoryStream = new MemoryStream();
                await document.File.CopyToAsync(memoryStream);
                var lastIndexOfDot = document.File.FileName.LastIndexOf('.');
                string extension = document.File.FileName.Substring(lastIndexOfDot + 1);

                var path = await supabase.Storage.From("documents").Upload(
                    memoryStream.ToArray(),
                    $"{doc.Id}.{extension}");
                if (string.IsNullOrEmpty(path))
                {
                    _logger.LogError("Failed to upload document to storage for taskId: {TaskId}", taskId);
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

                _logger.LogInformation("Document uploaded successfully to taskId: {TaskId}, documentId: {DocumentId}", taskId, doc.Id);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "Document uploaded to task successfully",
                };
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Failed to upload document to taskId: {TaskId}", taskId);
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Failed to upload document to task",
                    Errors = new List<string> { e.Message }
                };
            }
        }

        public async Task<BaseResponse<string>> UpdateDocumentAsync(UpdateDocumentRequest payload)
        {
            _logger.LogInformation("Updating document with ID: {Id}", payload?.Id);

            if (payload == null || payload.Id == Guid.Empty)
            {
                _logger.LogWarning("Invalid update payload.");
                return new BaseResponse<string> { Success = false, Message = "Invalid document update request" };
            }

            try
            {
                var doc = await GetByIdAsync(payload.Id);
                if (doc is null)
                {
                    _logger.LogWarning("Document with ID: {Id} not found for update", payload.Id);
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
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating document with ID: {Id}", payload?.Id);
                throw;
            }
        }

        public async Task<BaseResponse<string>> DeleteDocumentAsync(Guid id)
        {
            _logger.LogInformation("Deleting document with ID: {Id}", id);

            if (id == Guid.Empty)
            {
                _logger.LogWarning("Invalid document id for delete.");
                return new BaseResponse<string>
                {
                    Success = false,
                    Message = "Invalid document id"
                };
            }

            try
            {
                var doc = await GetByIdAsync(id);
                if (doc is null)
                {
                    _logger.LogWarning("Document with ID: {Id} not found for delete", id);
                    return new BaseResponse<string>
                    {
                        Success = false,
                        Message = "المستند غير موجود"
                    };
                }

                Delete(doc);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Document deleted successfully: {Id}", id);

                return new BaseResponse<string>
                {
                    Success = true,
                    Message = "تم حذف المستند بنجاح"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error deleting document with ID: {Id}", id);
                throw;
            }
        }
    }
}
