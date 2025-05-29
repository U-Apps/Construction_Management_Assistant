
namespace ConstructionManagementAssistant.Core.DTOs
{
    /// <summary>
    /// DTO for updating document metadata.
    /// </summary>
    public class UpdateDocumentRequest
    {
        [Required]
        public Guid Id { get; set; }

        [Required, StringLength(200)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string Description { get; set; }
    }
}
