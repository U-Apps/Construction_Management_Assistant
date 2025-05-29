using Microsoft.AspNetCore.Http;

namespace ConstructionManagementAssistant.Core.DTOs
{
    /// <summary>
    /// DTO for uploading a document file.
    /// </summary>
    public class UploadFileRequest
    {
        [StringLength(200)]
        public string? Name { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        //public int ProjectId/ { get; set; }
        //public int Proje/ctId { get; set; }

        [Required]
        public IFormFile? File { get; set; }
    }
}
