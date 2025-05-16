using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionManagementAssistant.EF.Repositories
{
    public class DocumentRepository(AppDbContext _context, ILogger<DocumentRepository> _logger)
                        : BaseRepository<Documnet>(_context), IDocumentRepository
    {
        public Core.Entites.Task AddDocumentAsync(Documnet document)
        {
            throw new NotImplementedException();
        }

        public Core.Entites.Task DeleteDocumentAsync(int id)
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

        public Core.Entites.Task UpdateDocumentAsync(Documnet document)
        {
            throw new NotImplementedException();
        }
    }
}
